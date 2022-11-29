using MongoDAB3.Services;

Console.WriteLine("Hello");
var Locationsservice = new LocationsService();
var bookingservice = new BookingService();
var keyResponsibleService = new KeyResponsibleService();
var societyService = new SocietyService();
var service8 = new MongoContextService();
Locationsservice.GetAllmunicipalityaddresses().ForEach(Console.WriteLine);
bookingservice.GetallBookings().ForEach(Console.WriteLine);
keyResponsibleService.Get("1");
societyService.GetAllsocieties("Reading");
