﻿using PGCEEL.Shared.Entities;

namespace PGCELL.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckTypeNoveltyAsync();
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

        //private async Task CheckCountriesAsync()
        // {
        //     if (!_context.Countries.Any())
        //     {
        //         _context.Countries.Add(new Country { Name = "Colombia" });
        //         _context.Countries.Add(new Country { Name = "Estados Unidos" });
        //         _context.Countries.Add(new Country { Name = "Argentina" });
        //         _context.Countries.Add(new Country { Name = "Bolivia" });
        //         _context.Countries.Add(new Country { Name = "Brasil" });
        //         _context.Countries.Add(new Country { Name = "Chile" });
        //         _context.Countries.Add(new Country { Name = "Costa Rica" });
        //         _context.Countries.Add(new Country { Name = "Ecuador" });
        //         _context.Countries.Add(new Country { Name = "Paraguay" });
        //         _context.Countries.Add(new Country { Name = "Perú" });
        //         _context.Countries.Add(new Country { Name = "Cuba" });
        //         _context.Countries.Add(new Country { Name = "Guatemala" });
        //         _context.Countries.Add(new Country { Name = "México" });
        //         _context.Countries.Add(new Country { Name = "Panamá" });
        //         _context.Countries.Add(new Country { Name = "Uruguay" });
        //         _context.Countries.Add(new Country { Name = "Venezuela" });
        //         _context.Countries.Add(new Country { Name = "Puerto Rico" });
        //         await _context.SaveChangesAsync();/
        //     }
        // }
        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
            {
                new State()
                {
                    Name = "Antioquia",
                    Cities = new List<City>() {
                        new City() { Name = "Medellín" },
                        new City() { Name = "Itagüí" },
                        new City() { Name = "Envigado" },
                        new City() { Name = "Bello" },
                        new City() { Name = "Rionegro" },
                    }
                },
                new State()
                {
                    Name = "Bogotá",
                    Cities = new List<City>() {
                        new City() { Name = "Usaquen" },
                        new City() { Name = "Champinero" },
                        new City() { Name = "Santa fe" },
                        new City() { Name = "Useme" },
                        new City() { Name = "Bosa" },
                    }
                },
            }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
            {
                new State()
                {
                    Name = "Florida",
                    Cities = new List<City>() {
                        new City() { Name = "Orlando" },
                        new City() { Name = "Miami" },
                        new City() { Name = "Tampa" },
                        new City() { Name = "Fort Lauderdale" },
                        new City() { Name = "Key West" },
                    }
                },
                new State()
                {
                    Name = "Texas",
                    Cities = new List<City>() {
                        new City() { Name = "Houston" },
                        new City() { Name = "San Antonio" },
                        new City() { Name = "Dallas" },
                        new City() { Name = "Austin" },
                        new City() { Name = "El Paso" },
                    }
                },
            }
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}