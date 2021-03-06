﻿using System;
using System.Collections.Generic;
using System.Text;
using DotNetCorePayroll.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DotNetCorePayroll.Console
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<PayrollContext>
    {
        public PayrollContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PayrollContext>();

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=Manbehind5;Database=payroll;");

            return new PayrollContext(optionsBuilder.Options);
        }
    }
}
