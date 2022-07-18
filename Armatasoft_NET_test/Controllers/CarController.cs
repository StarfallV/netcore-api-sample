using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json;

namespace Armatasoft_NET_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private List<Car> _cars = new List<Car>();

        private readonly ILogger<CarController> _logger;
        private void AddCars()
        {
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Fiesta", Transmission = "Manual", Price = 120000000 });
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Fiesta", Transmission = "Manual", Price = 134000000 });
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Fiesta", Transmission = "Automatic", Price = 140000000 });
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Fiesta", Transmission = "Automatic", Price = 150000000 });
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Focus", Transmission = "Manual", Price = 330000000 });
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Focus", Transmission = "Manual", Price = 335000000 });
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Focus", Transmission = "Manual", Price = 350000000 });
            _cars.Add(new Car() { Brand = "Ford", TypeName = "Focus", Transmission = "Automatic", Price = 360000000 });
            _cars.Add(new Car() { Brand = "VW", TypeName = "Golf", Transmission = "Manual", Price = 350000000 });
            _cars.Add(new Car() { Brand = "VW", TypeName = "Golf", Transmission = "Automatic", Price = 370000000 });
        }

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
            AddCars();
        }

        [HttpGet(Name = "GetCar")]
        public ActionResult<Response<List<CarDTO>>> Get()
        {
            try
            {
                var returnList = new List<CarDTO>();

                string _tempBrand = string.Empty;
                string _tempTypeName = string.Empty;
                string _tempTransmission = string.Empty;

                NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
                nfi.CurrencySymbol = "Rp";

                foreach (var car in _cars)
                {
                    if (_tempBrand == null && _tempTypeName == null & _tempTransmission == null)
                    {
                        var _tempCar = new CarDTO()
                        {
                            Brand = car.Brand,
                            TypeName = car.TypeName,
                            Transmission = car.Transmission,
                            Price = String.Format(nfi, "{0:C}", car.Price),
                        };
                        returnList.Add(_tempCar);
                    }
                    else
                    {
                        var _tempCar = new CarDTO();

                        if (_tempBrand == car.Brand)
                        {
                            _tempCar.Brand = String.Empty;
                        } else
                        {
                            _tempCar.Brand = car.Brand;
                        }

                        if (_tempTypeName == car.TypeName)
                        {
                            _tempCar.TypeName = String.Empty;
                        } else
                        {
                            _tempCar.TypeName = car.TypeName;
                        }

                        if (_tempTransmission == car.Transmission)
                        {
                            _tempCar.Transmission = String.Empty;
                        } else
                        {
                            _tempCar.Transmission = car.Transmission;
                        }

                        _tempCar.Price = String.Format(nfi, "{0:C}", car.Price);
                        returnList.Add(_tempCar);
                    }

                    //Assign to temporary for next index
                    _tempBrand = car.Brand;
                    _tempTypeName = car.TypeName;
                    _tempTransmission = car.Transmission;
                }

                var response = new Response<List<CarDTO>>();
                response.value = returnList;
                response.message = "OK";
                response.status = 200;

                return StatusCode((int)response.status, response);
            }
            catch (Exception ex)
            {
                var response = new Response<List<CarDTO>>();
                response.value = null;
                response.message = "Internal Server Error: " + ex.Message;
                response.status = 500;

                return StatusCode((int)response.status, response);
            }
        }
    }
}