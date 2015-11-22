using System.Collections.Generic;
using Project.Domain.Product;
using Project.Domain.Repositories;

namespace Project.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            // data could be retrieved from a db
            return MakeProducts();
        }

        private static IEnumerable<Product> MakeProducts()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Id = "TSESE",
                    Title = "The Seventh Season",
                    Author = "Kit Hudson",
                    Abstract =
                        "<p>This was the last wish of Kit Hudson, a remarkable academic who translated the fabled Aksum scrolls" +
                        " to reveal an incredible adventure story known as The Seventh Season.</p>" +
                        "<p>Narrated by a young man who worked for one of the Apostles, The Seventh Season offers a dramatic" +
                        " eyewitness account of the birth of Christianity. Written at a time when resistance movements against" +
                        " Roman occupation were reaching their height in Palestine and Greece, The Seventh Season depicts the" +
                        " epic struggle between the Roman Empire and those who wished to bring about its downfall.</p>",
                    Content =
                        "<p>In February 2013, I received a letter from the executor of a distant relative’s will informing me that" +
                        " I was one of the beneficiaries. My relative, Kit Hudson, was an academic and historian who moved to Greece in" +
                        " the 1960s for reasons that were never particularly clear. A few weeks after I received the executor’s letter," +
                        " a crate arrived from Greece containing oil pressed from olives grown in Kit’s garden and – at the bottom of the" +
                        " crate – an old leather box. When I opened the box, the first thing I saw was a handwritten note that simply said:</p>" +
                        "<p> Some secrets are meant to be told</p><p> Beneath the note were several hundred type - written" +
                        " pages of yellowed foolscap paper, and as I began to read I realised I had the original typescript of a book" +
                        " Kit had published in 1965.The Seventh Season – essentially an old fashioned epic adventure that just happens" +
                        " to feature one of the Apostles – had been translated from 2nd Century texts known as the Aksum Scrolls." +
                        " On publication, it seems The Seventh Season created a bit of a controversy(presumably because of the" +
                        " Christian content) and Kit went into hiding in Greece for the rest of his life.I read the text immediately" +
                        " and was dumbfounded that anyone could have found it controversial enough to condemn it – it really is" +
                        " just a ripping yarn with a mad Emperor(Nero), an ancient desert curse and some unrequited love thrown" +
                        " in for good measure – and I immediately knew I had to find a way of re - publishing the text.I'm delighted" +
                        " to say that it has just gone on sale and I feel like it’s my duty to bring it to as many people’s attention" +
                        " as possible.</p>"
                }
            };
            return products;
        }
    }
}
