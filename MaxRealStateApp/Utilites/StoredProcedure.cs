//using Dapper;
//using DataAccess.Entites;
//using DocumentFormat.OpenXml.ExtendedProperties;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Tokens;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System.Data;
//using System.Diagnostics;
//using Twilio.TwiML.Messaging;
//using WasiteeModels;
//using WasiteeModels.DataModels;

//namespace WasiteeApp.Utilites
//{
//    public class StoredProcedure
//    {
//        private readonly IConfiguration _config;
//        public StoredProcedure(IConfiguration _config)
//        {
//            this._config = _config;
//        }
//        public List<BusinessUserModel> getManagerDsa(int ManagerId)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@ManagerId", ManagerId);


//                var result = connection.Query<BusinessUserModel>(
//                    sql: "getManagerDSA",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }
//        public List<CBDCustomerData> getCBDData()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
                


//                var result = connection.Query<CBDCustomerData>(
//                    sql: "getCbdData",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public List<CBDCustomerData> BankDataAgent()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();



//                var result = connection.Query<CBDCustomerData>(
//                    sql: "BankDataAgent",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }


//        public List<CBDCustomerData> getfiltercbdDataData(string Search)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@SearchQuery", Search);



//                var result = connection.Query<CBDCustomerData>(
//                    sql: "GetFilteredLeads",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public List<BankMappingRequest> BankDataMapping()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                var result = connection.Query<BankMappingRequest>(
//                    sql: "BankMapping",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();
//                return result;
//            }
//        }

//        public List<DSAModel> getMappedDSA(string dsa)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
             
//                parameters.Add("@GofID", dsa);


//                var result = connection.Query<DSAModel>(
//                    sql: "getmappeddsaList",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }
//        public List<ManagerOverallPerformance> GetManagerOverallPerformance(int ManagerId,bool YearToDate, bool MonthToDate, bool Today)
//        {
          
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@ManagerId", ManagerId);
//                parameters.Add("@YearToDate", YearToDate);
//                parameters.Add("@MonthToDate", MonthToDate);
//                parameters.Add("@Today", Today);


//                var result = connection.Query<ManagerOverallPerformance>(
//                    sql: "GetManagerOverallPerformance",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public DataTable GetManagerTopThreeAgentsData(int ManagerId, DateTime StartDate, DateTime EndDate)
//        {
          
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@ManagerId", ManagerId);
//                parameters.Add("@StartDate", StartDate);
//                parameters.Add("@EndDate", EndDate);
              

//                var dataTable = new DataTable();
//                using (var reader = connection.ExecuteReader(
//                 sql: "ManagerSalesTopThreeAgentsV1",
//                    param: parameters,
//                     commandType: CommandType.StoredProcedure))
//                {
//                    dataTable.Load(reader);
//                }

//                return dataTable;
//            }
//        }

//        public List<ManagerTeamCountModel> getHeadTblData(int ManagerId)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@ManagerId", ManagerId);


//                var result = connection.Query<ManagerTeamCountModel>(
//                    sql: "GetManagerTeamInfo",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public List<ManagerTeamTrnModel> getTranHeadApprove(int ManagerId, DateTime StartDate, DateTime EndDate)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@ManagerId", ManagerId);
//                parameters.Add("@StartDate", StartDate);
//                parameters.Add("@EndDate", EndDate);


//                var result = connection.Query<ManagerTeamTrnModel>(
//                    sql: "GetManagerDashboardTbl",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public List<ManagerDashboard> getManagerApproval(int ManagerId, DateTime StartDate, DateTime EndDate)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@ManagerId", ManagerId);
//                parameters.Add("@StartDate", StartDate);
//                parameters.Add("@EndDate", EndDate);
               

//                var result = connection.Query<ManagerDashboard>(
//                    sql: "getManagerDashboardDatav1",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }
//        public List<PiTransactionModel> MyPlApplications()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                //parameters.Add("@AgentId", AgentId);
//                //parameters.Add("@Stage", stage);
        


//                var result = connection.Query<PiTransactionModel>(
//                    sql: "MyPlApplication",
//                    //param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }
//          public List<TranscationModel> PlBusinessManager(int ManagerId)
//          {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@MangerId", ManagerId);
        


//                var result = connection.Query<TranscationModel>(
//                    sql: "PiBusinessManger",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public List<TranscationModel> GetSalesTeamTranscationByLead(int TeamLeadId, ApplicationSearchModel filter)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@TeamLeaderId", TeamLeadId);
//                parameters.Add("@startDate", filter.startDate);
//                parameters.Add("@endDate", filter.endDate);
//                parameters.Add("@currentAgent", filter.currentAgent);


//                var result = connection.Query<TranscationModel>(
//                    sql: "GetMyTeamSalesTranscation",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }
//        public FreshLeadsTbl getnewSignleLead()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();




//                var result = connection.Query<FreshLeadsTbl>(
//                    sql: "getSingleFreahLead",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).FirstOrDefault();

//                return result;
//            }
//        }
//        public List<SytemLeads> GetAgentLeads(int agentId)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@agentId", agentId);



//                var result = connection.Query<SytemLeads>(
//                    sql: "getnewAgentLeads",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public List<SytemLeads> GetMyLeads(int agentId)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@agentId", agentId);



//                var result = connection.Query<SytemLeads>(
//                    sql: "getMyLeads",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }

//        public List<TeamLeaderDashboard_Table> GetTeamLeadDashboardStatisTable(int TeamID)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                parameters.Add("@TeamID", TeamID);

//                var result = connection.Query<TeamLeaderDashboard_Table>(
//                    sql: "GetTeamLeaderStatisTable",
//                     param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }


//        public DataTable GetAgentDashboard(int AgentID)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                parameters.Add("@AgentID", AgentID);

//                var dataTable = new DataTable();
//                using (var reader = connection.ExecuteReader(
//                    sql: "Agent_Dashboard",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure))
//                {
//                    dataTable.Load(reader);
//                }

//                return dataTable;
//            }
//        }


//        public DataTable SalesMTD(int AgentId, DateTime startDate, DateTime endDate)
//        {

//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@AgentId", AgentId);
//                parameters.Add("@StartDate", startDate);
//                parameters.Add("@EndDate", endDate);

//                var dataTable = new DataTable();
//                using (var reader = connection.ExecuteReader(
//                    sql: "SalesMTD",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure))
//                {
//                    dataTable.Load(reader);
//                }

//                return dataTable;
//            }
//        }



//        public DataTable GetLeaderDashboard(int TeamID, DateTime startDate, DateTime endDate)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                parameters.Add("@TeamID", TeamID);
//                parameters.Add("@startDate", startDate);
//                parameters.Add("@endDate", endDate);

//                var dataTable = new DataTable();
//                using (var reader = connection.ExecuteReader(
//                    sql: "Leader_Dashboard",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure))
//                {
//                    dataTable.Load(reader);
//                }

//                return dataTable;
//            }
//        }

//        public DataTable getCustomerDetails(int TeamLeadId, ApplicationSearchModel filter)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var parameters = new DynamicParameters();
//                parameters.Add("@TeamLeaderId", TeamLeadId);
//                parameters.Add("@startDate", filter.startDate);
//                parameters.Add("@endDate", filter.endDate);
//                parameters.Add("@currentAgent", filter.currentAgent);

//                var dataTable = new DataTable();
//                using (var reader = connection.ExecuteReader(
//                   sql: "GetMyTeamSalesTranscation",
//                   param: parameters,
//                   commandType: CommandType.StoredProcedure))
//                {
//                    dataTable.Load(reader);
//                }

//                return dataTable;
//            }
//        }

//        public DataTable GetTeamSalesTopThree(int TeamID, DateTime startDate, DateTime endDate)
//        {

//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                parameters.Add("@TeamID", TeamID);
//                parameters.Add("@startDate", startDate);
//                parameters.Add("@endDate", endDate);

//                var dataTable = new DataTable();
//                using (var reader = connection.ExecuteReader(
//                    sql: "TeamSalesTopThree",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure))
//                {
//                    dataTable.Load(reader);
//                }

//                return dataTable;
//            }
//        }



//        public DataTable GetTVDashboard(int bankID, int locationID)
//        {


//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                parameters.Add("@Bank", bankID);
//                parameters.Add("@Location", locationID);

//                var dataTable = new DataTable();
//                using (var reader = connection.ExecuteReader(
//                    sql: "TV_Dashboard",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure))
//                {
//                    dataTable.Load(reader);
//                }

//                return dataTable;
//            }
//        }

//        public BankDataCountModel GetCBDBankData()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var result = connection.QueryFirstOrDefault<BankDataCountModel>(
//                    sql: "GetBankDataCount",
//                    commandType: CommandType.StoredProcedure);

//                return result;
//            }
//        }
        
//        public ManagerCSModel ManagerCallSms(int ManagerId)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                parameters.Add("@ManagerId", ManagerId);

//                var result = connection.QueryFirstOrDefault<ManagerCSModel>(
//                    sql: "MangerCallsMessage",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure);

//                return result;
//            }
//        }

//        //pl csutomer dashboard count
//        public PlCountModel GetPlDashboard()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                //parameters.Add("@ManagerId", ManagerId);

//                var result = connection.QueryFirstOrDefault<PlCountModel>(
//                    sql: "GetPlCounts",
//                    //param: parameters,
//                    commandType: CommandType.StoredProcedure);

//                return result;
//            }
//        }
//        public List<LeaderMemberCalls> LeaderCalls()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var result = connection.QueryFirstOrDefault<string>(
//                    sql: "GetLeaderCallsHistory",
//                    commandType: CommandType.StoredProcedure);

//                var leaderMemberCallsList = new List<LeaderMemberCalls>();
//                if (!string.IsNullOrEmpty(result))
//                {
//                    leaderMemberCallsList = JsonConvert.DeserializeObject<List<LeaderMemberCalls>>(result);
//                }

//                return leaderMemberCallsList;
//            }
//        }

//        public List<TeamLeaderMappingModel> MappingTeamLeader()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var result = connection.Query<TeamLeaderMappingModel>(
//                    sql: "MappingTeamLeader",
//                    commandType: CommandType.StoredProcedure).ToList();
//                return result;
//            }
//        } 
//        public List<DsaMappingModel> DSAMapping()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var result = connection.Query<DsaMappingModel>(
//                    sql: "MappingSalesAgent",
//                    commandType: CommandType.StoredProcedure).ToList();
//                return result;
//            }
//        }
//        public List<BusinessUserModel> getDsaList()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();

//                var result = connection.Query<BusinessUserModel>(
//                    sql: "GetEmployeeList",
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }
       
//        public AdminHrModel getHrCount()
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                //parameters.Add("@ManagerId", ManagerId);

//                var result = connection.QueryFirstOrDefault<AdminHrModel>(
//                    sql: "GetStaffStatusCounts",
//                    //param: parameters,
//                    commandType: CommandType.StoredProcedure);

//                return result;
//            }
//        }

//        public List<EnbModel> getSubmitApplication(int agentId)
//        {
//            using (var connection = new SqlConnection(_config.GetConnectionString("WasiteeDb")))
//            {
//                connection.Open();
//                var parameters = new DynamicParameters();
//                parameters.Add("@AgentId", agentId);

//                var result = connection.Query<EnbModel>(
//                    sql: "GetSubmitDsaApplication",
//                    param: parameters,
//                    commandType: CommandType.StoredProcedure).ToList();

//                return result;
//            }
//        }


//    }
//}
