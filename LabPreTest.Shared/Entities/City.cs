﻿using System.ComponentModel.DataAnnotations;
using LabPreTest.Shared.Interfaces;

namespace LabPreTest.Shared.Entities
{
    public class City : IEntityWithName
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }

        public State? State { get; set; }
    }
}