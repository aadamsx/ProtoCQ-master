using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Proto.Data.Query;
using Proto.Domain.CommandHandlers;
using Proto.Domain.Commands;
using Proto.Domain.Commands.Tenants;
using Proto.Domain.Queries.Tenants;
using Proto.Domain.QueryHandlers;
using Proto.Mvc.Mgmt.Models;

namespace Proto.Mvc.Mgmt.Controllers
{
    public class TenantController : Controller
    {
        //private ClientManagementContextEntities db = new ClientManagementContextEntities();
        private readonly IQueryHandler<GetCurrentTenantsQuery, IEnumerable<AllTenants>> getCurrentTenantsHandler;
        private readonly IQueryHandler<GetTenantByIdQuery, AllTenants> getTenantByIdHandler;
        private readonly ICommandHandler<CreateOrUpdateTenantCommand> createOrUpdateTenantHandler;
        private readonly ICommandHandler<DeleteTenantCommand> deleteTenantHandler;

        public TenantController(
            IQueryHandler<GetCurrentTenantsQuery, IEnumerable<AllTenants>> getcurrenttenants,
            IQueryHandler<GetTenantByIdQuery, AllTenants> gettenantbyidquery,
            ICommandHandler<CreateOrUpdateTenantCommand> createorupdatetenanthandler,
            ICommandHandler<DeleteTenantCommand> deletetenanthandler)
        {
            getCurrentTenantsHandler = getcurrenttenants;
            getTenantByIdHandler = gettenantbyidquery;
            createOrUpdateTenantHandler = createorupdatetenanthandler;
            deleteTenantHandler = deletetenanthandler;
        }

        // GET: /TenantManagement/
        public ActionResult Index()
        {
            var query = new GetCurrentTenantsQuery { PageIndex = 1, PageSize = 10 };
            var domainModel = getCurrentTenantsHandler.Handle(query);
            return View(Mapper.Map<IEnumerable<AllTenants>, IEnumerable<TenantViewModel>>(domainModel));
        }

        // GET: /TenantManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tenantDetail = getTenantByIdHandler.Handle(new GetTenantByIdQuery { TenantId = (int)id });
            return tenantDetail == null
                ? (ActionResult) HttpNotFound()
                : View(Mapper.Map<AllTenants, TenantViewModel>(tenantDetail));
        }

        // GET: /TenantManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TenantManagement/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TenantViewModel tenant)
        {
            if (ModelState.IsValid)
             {
                var command = Mapper.Map<TenantViewModel, CreateOrUpdateTenantCommand>(tenant);
                createOrUpdateTenantHandler.Handle(command);

                return RedirectToAction("Index");
            }

            return View(tenant);
        }

        // GET: /TenantManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tenantDetail = getTenantByIdHandler.Handle(new GetTenantByIdQuery { TenantId = (int)id });
            return tenantDetail == null
                ? (ActionResult)HttpNotFound()
                : View(Mapper.Map<AllTenants, TenantViewModel>(tenantDetail));
        }

        // POST: /TenantManagement/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TenantViewModel tenant)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<TenantViewModel, CreateOrUpdateTenantCommand>(tenant);
                createOrUpdateTenantHandler.Handle(command);

                return RedirectToAction("Index");
            }
            return View(tenant);
        }

        // GET: /TenantManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tenant = getTenantByIdHandler.Handle(new GetTenantByIdQuery { TenantId = (int)id });
            return tenant == null
                ? (ActionResult)HttpNotFound()
                : View(Mapper.Map<AllTenants, TenantViewModel>(tenant));
        }

        // POST: /TenantManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var command = new DeleteTenantCommand {TenantId = id};
            deleteTenantHandler.Handle(command);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}