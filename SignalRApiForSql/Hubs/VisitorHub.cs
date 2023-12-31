﻿using Microsoft.AspNetCore.SignalR;
using SignalRApiForSql.Model;

namespace SignalRApiForSql.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task ReceiveVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList", _visitorService.GetVisitorChartList);
        }
    }
}
