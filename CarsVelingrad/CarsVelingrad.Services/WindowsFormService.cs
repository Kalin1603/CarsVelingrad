namespace CarsVelingrad.Services
{
    using CarsVelingrad.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WindowsFormService
    {
        private ApplicationDbContext dbContext;

        public WindowsFormService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public object[] GetBrands() 
        {
            return this.dbContext.Brands.Select(x => x.Name).ToArray();
        }

        public object[] GetModels()
        {
            return this.dbContext.Models.Select(x => x.Name).ToArray();
        }
    }
}
