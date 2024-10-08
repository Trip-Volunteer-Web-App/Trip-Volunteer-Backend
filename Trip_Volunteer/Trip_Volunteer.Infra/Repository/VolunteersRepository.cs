﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Repository;

namespace Trip_Volunteer.Infra.Repository
{
    public class VolunteersRepository : IVolunteersRepository
    {
        private readonly IDbContext _dbContext;

        public VolunteersRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Volunteer> GetAllVolunteers()
        {
            IEnumerable<Volunteer> result = _dbContext.Connection.Query<Volunteer>("volunteers_package.GatAllVolunteers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Volunteer GetVolunteerById(int id)
        {
            var p = new DynamicParameters();
            p.Add("V_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Volunteer>("volunteers_package.GetVolunteerById", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void CreateVolunteer(Volunteer volunteer)
        {
            var p = new DynamicParameters();
            p.Add("LoginId", volunteer.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TripId", volunteer.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("VolunteerRoleId", volunteer.Volunteer_Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_Experience", volunteer.Experience, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_PhoneNumber", volunteer.Phone_Number, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_Email", volunteer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_Status", volunteer.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Application_date", volunteer.Date_Applied, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("V_Notes", volunteer.Notes, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_EmergencyContacts", volunteer.Emergency_Contact, dbType: DbType.String, direction: ParameterDirection.Input);
           
            _dbContext.Connection.Execute("volunteers_package.CreateVolunteer", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateVolunteer(Volunteer volunteer)
        {
            var p = new DynamicParameters();
            p.Add("V_Id", volunteer.Volunteer_Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("LoginId", volunteer.Login_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TripId", volunteer.Trip_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("VolunteerRoleId", volunteer.Volunteer_Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_Experience", volunteer.Experience, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_PhoneNumber", volunteer.Phone_Number, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("V_Email", volunteer.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_Status", volunteer.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Application_date", volunteer.Date_Applied, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("V_Notes", volunteer.Notes, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_EmergencyContacts", volunteer.Emergency_Contact, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("volunteers_package.UpdateVolunteer", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteVolunteer(int id)
        {
            var p = new DynamicParameters();
            p.Add("V_Id", id, DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("volunteers_package.DeleteVolunteer", p, commandType: CommandType.StoredProcedure);
        }
    }
}
