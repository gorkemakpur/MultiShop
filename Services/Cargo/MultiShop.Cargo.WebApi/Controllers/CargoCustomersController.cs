using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address=createCargoCustomerDto.Address,
                City=createCargoCustomerDto.City,
                District=createCargoCustomerDto.District,
                Email=createCargoCustomerDto.Email,
                Name=createCargoCustomerDto.Name,
                PhoneNumber = createCargoCustomerDto.PhoneNumber,
                Surname = createCargoCustomerDto.Surname
            };

            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo Müşteri Ekleme İşlemi Başarıyla Yapıldı");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Müşteri Silme İşlemi Başarıyla Yapıldı");
        }

        [HttpGet]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId=updateCargoCustomerDto.CargoCustomerId,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                PhoneNumber = updateCargoCustomerDto.PhoneNumber,
                Surname = updateCargoCustomerDto.Surname
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Müşteri Güncelleme İşlemi Başarıyla Yapıldı");
        }
    }
}
