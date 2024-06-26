﻿using LabPreTest.Shared.Interfaces;
using LabPreTest.Shared.Messages;
using System.ComponentModel.DataAnnotations;

namespace LabPreTest.Shared.Entities
{
    public class TestTube : IEntityWithId, IEntityWithDescription
    {
        public int Id { get; set; }

        [Display(Name = EntityMessages.TestTubeDisplayName)]
        [MaxLength(100, ErrorMessage = EntityMessages.MaxLengthErrorMessage)]
        [Required(ErrorMessage = EntityMessages.RequiredErrorMessage)]
        public string Name { get; set; } = null!;

        [Display(Name = EntityMessages.DescriptionDisplayName)]
        [MaxLength(300, ErrorMessage = EntityMessages.MaxLengthErrorMessage)]
        [Required(ErrorMessage = EntityMessages.RequiredErrorMessage)]
        public string Description { get; set; } = null!;

        public ICollection<Test>? Tests { get; set; }
        public int TestNumber => Tests == null || Tests.Count == 0 ? 0 : Tests.Count;
    }
}