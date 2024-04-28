﻿using LabPreTest.Shared.DTO;
using LabPreTest.Shared.Entities;
using LabPreTest.Shared.Responses;

namespace LabPreTest.Backend.UnitOfWork.Interfaces
{
    public interface IPatientUnitOfWork
    {
        Task<ActionResponse<IEnumerable<Patient>>> GetAsync();

        Task<ActionResponse<Patient>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Patient>>> GetAsync(PagingDTO paging);

        Task<ActionResponse<int>> GetTotalPagesAsync(PagingDTO pagination);
    }
}