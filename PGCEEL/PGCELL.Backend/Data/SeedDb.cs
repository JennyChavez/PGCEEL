using Microsoft.EntityFrameworkCore;
using PGCEEL.Shared.Entities;
using PGCEEL.Shared.Responses;
using PGCELL.Backend.Services;
using System.Data;

namespace PGCELL.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;

        public SeedDb(DataContext context, IApiService apiService)
        {
            _context = context;
            _apiService = apiService;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckTypeNoveltyAsync();
            await CheckWorkersAsync();
            await CheckRolesAsync();
            await CheckModalitiesAsync();
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
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 1" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 2" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 3" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 4" });
                _context.Modalities.Add(new Modality { Name = "Modalidad futura 5" });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolesAsync()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.Add(new Role { Name = "Administrador" });
                _context.Roles.Add(new Role { Name = "Editor" });
                _context.Roles.Add(new Role { Name = "Observador" });               

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