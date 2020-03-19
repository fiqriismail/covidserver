using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServiceAPI.DataAccess;
using ServiceAPI.Models;
using ServiceAPI.Models.Mapper;

namespace ServiceAPI.Services
{
    public class StatisticsService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly StatsDbContext _context;

        public StatisticsService(IHttpClientFactory clientFactory, StatsDbContext context)
        {
            _clientFactory = clientFactory;
            _context = context;
        }
        public async Task GetAndPopulate()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://hpb.health.gov.lk/api/get-current-statistical");
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var stat = JsonConvert.DeserializeObject<StatsMapper>(responseContent);

                if (stat.Success)
                {
                    PopulateDashboard(stat);
                }
            }

        }
        public void PopulateDashboard(StatsMapper mapper)
        {
            var dashboard = mapper.Data;
            var hospitalData = mapper.Data.HospitalData;

            var newDashboard = _context.Dashboards.FirstOrDefault(d => d.UpdatedDateTime == dashboard.UpdatedDateTime);

            if (newDashboard == null)
            {
                dashboard.HospitalData = null;
                _context.Dashboards.Add(dashboard);
                _context.SaveChanges();

                // save the hospital data
                PopulateHospitalData(hospitalData);
            }

        }

        public void PopulateHospitalData(List<HospitalData> data)
        {
            if (data.Count > 0)
            {
                foreach (var hospital in data)
                {
                    var newHospitalData = new HospitalData
                    {
                        CreatedAt = hospital.CreatedAt,
                        CumulativeForeign = hospital.CumulativeForeign,
                        CumulativeLocal = hospital.CumulativeLocal,
                        CumulativeTotal = hospital.CumulativeTotal,
                        HospitalId = hospital.HospitalId,
                        TreatmentForeign = hospital.TreatmentForeign,
                        TreatmentLocal = hospital.TreatmentLocal,
                        TreatmentTotal = hospital.TreatmentTotal
                        
                    };

                    _context.HospitalStats.Add(newHospitalData);
                    _context.SaveChanges();
                }
            }
        }
    }
}
