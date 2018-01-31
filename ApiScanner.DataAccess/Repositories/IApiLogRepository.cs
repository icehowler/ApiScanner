﻿using ApiScanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiScanner.DataAccess.Repositories
{
    public interface IApiLogRepository
    {
        /// <summary>
        /// Log an api call response.
        /// </summary>
        /// <param name="apiLog"></param>
        /// <returns></returns>
        Task LogAsync(ApiLogModel apiLog);

        /// <summary>
        /// Get api logs by specific api id.
        /// </summary>
        /// <param name="id">Api id.</param>
        /// <param name="dateFrom">Date from when to get api logs. Will return all if null.</param>
        /// <returns></returns>
        Task<IEnumerable<ApiLogModel>> GetApiLogsAsync(Guid id, DateTime? dateFrom);
    }
}
