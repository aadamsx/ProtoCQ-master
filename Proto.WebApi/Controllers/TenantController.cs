//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using AutoMapper;
//using Proto.Domain.Queries.Tenants;
//using Proto.Domain.QueryHandlers;
//using Proto.Model.Entities;
//using Proto.WebApi.Models;

//namespace Proto.WebApi.Controllers
//{
//    public class HyperLink
//    {
//        public string Rel { get; set; }
//        public string Href { get; set; }
//    }

//    [RoutePrefix("api/tenants")]
//    public class TenantController : ApiController
//    {
//        IQueryHandler<GetTenantByIdQuery, Tenant> getTenant;
//        IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>> getTenants;

//        public TenantController(
//            IQueryHandler<GetTenantByIdQuery, Tenant> getTenant,
//            IQueryHandler<GetTenantsQuery, IEnumerable<Tenant>> getTenants)
//        {
//            this.getTenant = getTenant;
//            this.getTenants = getTenants;
//        }

//        // GET api/<controller>
//        [HttpGet(RouteName = "GetTenant")]
//        public IEnumerable<Tenant> Get()
//        {
//            var query = new GetTenantsQuery {PageIndex = 1, PageSize = 10};

//            if (getTenants != null) 
//                return getTenants.Handle(query);

//            throw new HttpResponseException(HttpStatusCode.NotFound);
//        }

//        // GET api/<controller>/5
//        [HttpGet("{id:int}", RouteName = "GetTenantById")]
//        public HttpResponseMessage Get(int id)
//        {
//            if (getTenants == null)
//                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Object not found.");
//            var query = new GetTenantByIdQuery {TenatId = id};
//            var tenant = getTenant.Handle(query);
//            if (tenant == null) Request.CreateResponse(HttpStatusCode.NotFound);
//            var tenantModel = Mapper.DynamicMap<TenantModel>(tenant);
//            return Request.CreateResponse(HttpStatusCode.OK, tenantModel);
//            //return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "Object not found.");
//        }   

//        // POST api/<controller>
//        public HttpResponseMessage Post(Tenant tenant)
//        {
//            // save the tenant
//            var id = 123;
//            var response = Request.CreateResponse(HttpStatusCode.Created);
//            // the tenant is created, and set the location to this link
//            response.Headers.Location = new Uri("/api/tenants/" + id, UriKind.Relative);
//            return response;
//        }

//        // PUT api/<controller>/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        public void Delete(int id)
//        {
//        }
//    }
//}