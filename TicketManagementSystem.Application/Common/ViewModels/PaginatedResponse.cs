﻿namespace TicketManagementSystem.Application.Common.ViewModels
{
    public class PaginatedResponse<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
