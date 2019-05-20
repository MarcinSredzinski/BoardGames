using Core.Library.Entities;
using Core.Library.Persistance;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BoardGames.Web.Controllers
{
    public class BaseController<T> : Controller where T : BaseEntity
    {
        private IRepositoryBase<T> _repository;

        public BaseController(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        // GET: ControllerName
        public virtual async Task<ActionResult> Index()
        {
            return View(await _repository.FindAllAsync());
        }

        // GET: ControllerName/Details/5
        public virtual async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int nnid = id.GetValueOrDefault();
            var entity = await _repository.GetDetailsAsync(nnid);

            return View(entity);

        }

        // GET: ControllerName/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: ControllerName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create([Bind(Include = "Id")] T entity)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(entity);
                await _repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: ControllerName/Edit/5
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int nnid = id.GetValueOrDefault();
            var entity = await _repository.GetDetailsAsync(nnid);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: ControllerName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(int id, [Bind(Include = "Id")] T entity)
        {
            if (id != entity.Id)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(entity);
                    await _repository.SaveAsync();
                }
                catch (Exception except)
                {
                    if (await _repository.GetDetailsAsync(entity.Id) == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        throw except;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: ControllerName/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            int ID = id.GetValueOrDefault();
            var entity = await _repository.GetDetailsAsync(ID);
            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        // POST: ControllerName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            _repository.Delete(await _repository.GetDetailsAsync(id));
            await _repository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}