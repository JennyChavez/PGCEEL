using Microsoft.EntityFrameworkCore;
using PGCEEL.Backend.Data;
using PGCEEL.Backend.Helpers;
using PGCEEL.Shared.Entities;
using PGCEEL.Shared.Enums;
using PGCEEL.Shared.Responses;
using PGCELL.Backend.Intertfaces;
using PGCELL.Backend.Services;

namespace PGCELL.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;
        private readonly IUserHelper _userHelper;
        private readonly IFileStorage _fileStorage;
        private readonly IRuntimeInformationWrapper _runtimeInformationWrapper;
        

        public SeedDb(DataContext context, IApiService apiService, IUserHelper userHelper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
            //_fileStorage = fileStorage;
            //_runtimeInformationWrapper = runtimeInformationWrapper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckTypeNoveltyAsync();
            await CheckWorkersAsync();
            await CheckRolesAsync();
            await CheckModalitiesAsync();
            await CheckUserAsync("1234567890", "Jenny Carolina", "Chavez", "jennycaro13@gmail.com", "312 345 45 67", "Calle 40 sur N 78 - 90 ", UserType.Admin);

        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "1234567890");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckModalitiesAsync()
        {
            if (!_context.Modalities.Any())
            {
                _context.Modalities.Add(new Modality { Name = "Contrato por obra o labor" });
                _context.Modalities.Add(new Modality { Name = "Contrato de trabajo a término fijo" });
                _context.Modalities.Add(new Modality { Name = "Contrato de trabajo a término indefinido" });
                _context.Modalities.Add(new Modality { Name = "Contrato de aprendizaje" });
                _context.Modalities.Add(new Modality { Name = "Contrato temporal, ocasional o accidental" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 1 contrato por hora" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 2 contrato por semana" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 3 contrato por mes" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 4 contrato por minutos" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 5 contrato por terceros" });

                await _context.SaveChangesAsync();
            }
        }
      
        private async Task CheckWorkersAsync()
        {
            if (!_context.Workers.Any())
            {
                _context.Workers.Add(new Worker { Name = "William" });
                _context.Workers.Add(new Worker { Name = "Sergio" });
                _context.Workers.Add(new Worker { Name = "Jenny" });
                _context.Workers.Add(new Worker { Name = "Karen" });
                _context.Workers.Add(new Worker { Name = "Lucas" });
                _context.Workers.Add(new Worker { Name = "Luis" });
                _context.Workers.Add(new Worker { Name = "Martha" });
                _context.Workers.Add(new Worker { Name = "Miguel" });
                _context.Workers.Add(new Worker { Name = "Patricia" });
                _context.Workers.Add(new Worker { Name = "Carmen" });                

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckTypeNoveltyAsync()
        {
            if (!_context.TypesNovelties.Any())
            {
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Vacaciones" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia por maternidad" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia por paternidad" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia por grave calamidad doméstica" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia por luto" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia para entierro de compañeros" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia como consecuencia del desempeño de cargos oficiales" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia para ejercer el derecho al voto" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Licencia sindical" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Permiso sindical" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Permiso de lactancia" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Permiso académico compensado" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Permiso para ejercer la docencia universitaria" });
                _context.TypesNovelties.Add(new TypeNovelty { Name = "Descansos" });

                await _context.SaveChangesAsync();
            }
        }


        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                var responseCountries = await _apiService.GetAsync<List<CountryResponse>>("/v1", "/countries");
                if (responseCountries.WasSuccess)
                {
                    var countries = responseCountries.Result!;
                    foreach (var countryResponse in countries)
                    {
                        var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                        if (country == null)
                        {
                            country = new() { Name = countryResponse.Name!, States = new List<State>() };
                            var responseStates = await _apiService.GetAsync<List<StateResponse>>("/v1", $"/countries/{countryResponse.Iso2}/states");
                            if (responseStates.WasSuccess)
                            {
                                var states = responseStates.Result!;
                                foreach (var stateResponse in states!)
                                {
                                    var state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                    if (state == null)
                                    {
                                        state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                        var responseCities = await _apiService.GetAsync<List<CityResponse>>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                        if (responseCities.WasSuccess)
                                        {
                                            var cities = responseCities.Result!;
                                            foreach (var cityResponse in cities)
                                            {
                                                if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                {
                                                    continue;
                                                }
                                                var city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                                if (city == null)
                                                {
                                                    state.Cities.Add(new City() { Name = cityResponse.Name! });
                                                }
                                            }
                                        }
                                        if (state.CitiesNumber > 0)
                                        {
                                            country.States.Add(state);
                                        }
                                    }
                                }
                            }
                            if (country.StatesNumber > 0)
                            {
                                _context.Countries.Add(country);
                                await _context.SaveChangesAsync();
                            }
                        }

                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}