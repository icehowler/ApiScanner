﻿using ApiScanner.Business.Identity;
using ApiScanner.DataAccess.Repositories;
using ApiScanner.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiScanner.Business.Managers
{
    [Authorize]
    public class ApiManager : IApiManager
    {
        private readonly IApiRepository _apiRepo;
        private readonly IAccountService _accountSvc;

        public ApiManager(IApiRepository apiRepo, IAccountService accountSvc)
        {
            _apiRepo = apiRepo;
            _accountSvc = accountSvc;
        }
        
        public async Task<bool> CreateAsync(ApiModel api)
        {
            var account = await _accountSvc.AccountData();
            if (account == null)
                return false;
            api.User = account;
            await _apiRepo.CreateAsync(api);
            return true;
        }

        public async Task<IEnumerable<ApiModel>> GetApisAsync(bool includeConditions, bool includeLocations)
        {
            var account = await _accountSvc.AccountData();
            if (account == null)
                return new List<ApiModel>();
            return await _apiRepo.GetApisAsync(account.Id, includeConditions, includeLocations);
        }

        public async Task<ApiModel> GetApiAsync(Guid apiId, bool includeConditions, bool includeLocations)
        {
            var account = await _accountSvc.AccountData();
            if (account == null)
                return null;
            var api = await _apiRepo.GetApiAsync(apiId, includeConditions, includeLocations);
            if (api == null || (!api.PublicRead && !api.PublicWrite && api.UserId != account.Id))
                return null;
            return api;
        }

        public async Task<bool> CanSeeApiAsync(Guid apiId)
        {
            var account = await _accountSvc.AccountData();
            if (account == null)
                return false;
            var api = await _apiRepo.GetApiAsync(apiId, false, false);
            if (api == null || (account.Id != api.UserId && !api.PublicRead && !api.PublicWrite))
                return false;
            return true;
        }

        public async Task<bool> DeleteApiAsync(Guid apiId)
        {
            var account = await _accountSvc.AccountData();
            if (account == null)
                return false;
            var api = await _apiRepo.GetApiAsync(apiId, false, false);
            if (api == null || (account.Id != api.UserId && !api.PublicWrite))
                return false;
            await _apiRepo.DeleteApiAsync(apiId);
            return true;
        }

        public async Task<bool> UpdateApiAsync(ApiModel api)
        {
            var account = await _accountSvc.AccountData();
            if (account == null)
                return false;
            var myApi = await _apiRepo.GetApiAsync(api.ApiId, false, false);
            if (myApi == null || (account.Id != myApi.UserId && !myApi.PublicWrite))
                return false;
            await _apiRepo.UpdateApiAsync(api);
            return true;
        }
    }
}
