using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        private Car carToDelete;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 2, BrandId = 3, ColorId = 2, ModelYear = 1930, DailyPrice = 132, Description = "Transit Taşımcaılığı" },
                new Car{CarId = 4, BrandId = 3, ColorId = 3, ModelYear = 1960, DailyPrice = 162, Description = "Spor" },
                new Car{CarId = 6, BrandId = 3, ColorId = 4, ModelYear = 1980, DailyPrice = 192, Description = "Aile" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
           _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }
    }
}
