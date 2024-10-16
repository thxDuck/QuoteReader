using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteReader.Data;
using QuoteReader.Services;

namespace QuoteReader.Controllers
{
    public class QuoteController : Controller
    {
        private readonly QuoteReaderContext _context;

        private readonly QuoteService _quoteService = new(
            new HttpService(),
            new HtmlParserService(),
            new QuoteExtractorService());


        public QuoteController(QuoteReaderContext context)
        {
            _context = context;
        }

        // GET: Quote
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quote.ToListAsync());
        }

        // GET: Quote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();


            var quote = await _context.Quote
                .FirstOrDefaultAsync(m => m.Id == id);

            if (quote != null) return View(quote);

            var newQuote = await _quoteService.GetQuoteFromWeb((int)id);
            if (newQuote is null) return NotFound();

            newQuote.Viewed = false;

            this._context.Add(newQuote);
            await this._context.SaveChangesAsync();

            return View(newQuote);
        }

        // GET: Quote/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quote/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Viewed,PostedDate")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quote.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        // POST: Quote/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Viewed,PostedDate")] Quote quote)
        {
            if (id != quote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quote
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quote = await _context.Quote.FindAsync(id);
            if (quote != null)
            {
                _context.Quote.Remove(quote);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
            return _context.Quote.Any(e => e.Id == id);
        }
    }
}
