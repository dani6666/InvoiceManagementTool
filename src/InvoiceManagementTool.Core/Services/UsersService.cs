﻿using InvoiceManagementTool.Core.Interfaces;
using InvoiceManagementTool.Core.Interfaces.Services;
using InvoiceManagementTool.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementTool.Core.Services
{
    public class UsersService : ILoginUserService
    {
        private readonly ISqlDatabaseConnector _sqlDatabaseConnector;

        public UsersService(ISqlDatabaseConnector sqlDatabaseConnector)
        {
            _sqlDatabaseConnector = sqlDatabaseConnector;
        }

        public Roles? ValidateUser(string login, string password)
        {
            return Roles.Admin;
        }
    }
}
