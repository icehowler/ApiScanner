﻿using ApiScanner.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiScanner.Business.Managers
{
    public interface IApiLogManager
    {
        /// <summary>
        /// Get api logs by specific api id.
        /// </summary>
        /// <param name="id">Api id.</param>
        /// <param name="dateFrom">Date from when to get api logs. Will return all if null.</param>
        /// <returns></returns>
        Task<IEnumerable<ApiLogDTO>> GetApiLogsAsync(Guid id, DateTime? dateFrom);

        /// <summary>
        /// Get api logs by specific widget id.
        /// </summary>
        /// <param name="widgetId">Widget id.</param>
        /// <param name="dateFrom">Date from when to get api logs. Will return all if null.</param>
        /// <returns></returns>
        Task<IEnumerable<ApiLogDTO>> GetApiLogsByWidgetAsync(Guid widgetId, DateTime? dateFrom);
    }
}
