using CarSaleProject.Data;
using CarSaleProject.Models;

namespace CarSaleProject.Repositories
{
    public class CarRepository : ICarRepository
    {
        private List<CarDTO> _cars = new List<CarDTO>();

        private readonly DataContext _context;

        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCar(CarDTO _car)
        {
            Car car = new Car();
            
            car.Price = _car.Price;
            car.ListingDate = _car.ListingDate;
            car.Brand = _car.Brand;
            car.Series = _car.Series;
            car.Model = _car.Model;
            car.Kilometers = _car.Kilometers;
            car.FilePath = _car.FilePath;
           

            _context.Cars.Add(car);
            _context.SaveChanges();

            //_cars.Add(car);
        }

        public List<CarDTO> GetAllCars()
        {
            return _cars;
        }

        public CarDTO GetCarByListingNumber(int listingNumber)
        {
            foreach (var car in _cars) { 
               
                if(car.ListingNumber == listingNumber)
                {
                    return car;
                }
            }
            return null;
        }

        public void UpdateCar(CarDTO car)
        {
            var existingCar = GetCarByListingNumber(car.ListingNumber);
            if (existingCar != null)
            {
                existingCar.Price = car.Price;
                existingCar.ListingDate = car.ListingDate;
                existingCar.Brand = car.Brand;
                existingCar.Series = car.Series;
                existingCar.Model = car.Model;
            }
        }

        public void DeleteCar(CarDTO car)
        {
            _cars.Remove(car);           
        }
    }
}

