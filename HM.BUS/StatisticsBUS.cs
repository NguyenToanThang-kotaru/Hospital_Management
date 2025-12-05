using HM.DAO;
using HM.DTO;
using System.Collections.Generic;

namespace HM.BUS
{
    
    public class StatisticsBUS
    {
        private StatisticDAO statisticDAO;
        private List<StatisticDTO> listDTO;
        public StatisticsBUS()
        {
            statisticDAO = new StatisticDAO();
            listDTO = new List<StatisticDTO>();
        }
        public List<StatisticDTO> GetServiceStatistics(string fromDate, string toDate)
        {
            listDTO = statisticDAO.GetServiceStatistics(fromDate, toDate);
            if (listDTO == null) {
                return null;
            }
            return listDTO;
        }
    }
}
