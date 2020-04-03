using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarApp.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string VehicleRegistration { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Direkcija { get; set; }
        public string BrojNaShasija { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PrvaRegistracija { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegistriranaDo { get; set; }
        public bool Defekt { get; set; }
        public bool Zadolzhena { get; set; }
        public string TipNaVozilo { get; set; }
        public string ImeNaDolzhnik { get; set; }
    }
}
