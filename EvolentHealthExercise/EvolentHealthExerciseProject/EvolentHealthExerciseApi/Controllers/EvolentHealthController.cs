using EvolentHealthBusinessLayer;
using EvolentHealthDataModel;
using EvolentHealthExerciseApi.Filters;
using EvolentHealthExerciseApi.Models;
using EvolentHealthExerciseApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EvolentHealthExerciseApi.Controllers
{
    [RoutePrefix("api")]
    [EvolentHealthExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EvolentHealthController : ApiController
    {
        private readonly IContactBL _contact;
        public EvolentHealthController(IContactBL contact)
        {
            _contact = contact;
        }
        [HttpGet]
        [Route("GetContacts/{status?}")]
        public ApiResponse<List<Contact>> GetContacts(bool? status = null)
        {
            try
            {
                var data = _contact.GetContactes(status);
                return ApiUtility.ApiSuccess<List<Contact>>(data);
            }
            catch (Exception ex)
            {
                return ApiUtility.ApiError<List<Contact>>(ex);
            }

        }
        [HttpGet]
        [Route("GetContactById/{id}")]
        public ApiResponse<Contact> GetContactById(int id)
        {
            try
            {
                var data = _contact.GetContactById(id);
                return ApiUtility.ApiSuccess<Contact>(data);
            }
            catch (Exception ex)
            {
                return ApiUtility.ApiError<Contact>(ex);
            }
        }
        [HttpPost]
        [Route("AddContact")]
        [ValidateModel]
        public ApiResponse<bool> AddContact(Contact contact)
        {
            try
            {
                var data = _contact.AddContact(contact);
                return ApiUtility.ApiSuccess<bool>(data);
            }
            catch (Exception ex)
            {
                return ApiUtility.ApiError<bool>(ex);
            }
        }
        [HttpPut]
        [Route("EditContact")]
        [ValidateModel]
        public ApiResponse<bool> EditContact(Contact contact)
        {
            try
            {
                var data = _contact.EditContact(contact);
                return ApiUtility.ApiSuccess<bool>(data);
            }
            catch (Exception ex)
            {
                return ApiUtility.ApiError<bool>(ex);
            }
        }

        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public ApiResponse<bool> DeleteContact(int id)
        {
            try
            {
                var data = _contact.DeleteContact(id);
                return ApiUtility.ApiSuccess<bool>(data);
            }
            catch (Exception ex)
            {
                return ApiUtility.ApiError<bool>(ex);
            }
        }
    }
}
