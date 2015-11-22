using System.Collections.Generic;
using System.Linq;
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

        public Product GetProduct(string productId)
        {
            var products = MakeProducts();
            return products.Single(e => e.Id == productId);
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
                },
                new Product()
                {
                    Id = "TAOS",
                    Title = "The Arrow of Sherwood",
                    Author = "Lauren Johnson",
                    Abstract =
                        "<p>The story of Robin Hood is one that has bewitched me since I was a child. Many is the woodland" +
                        " walk where I toddled along in my wellies and mack, dawdling behind my parents as I imagined outlaws" +
                        " hidden in the ruins of tumbledown walls, or scurrying between the shelter of trees. But my story of" +
                        " Robin, which ultimately became The Arrow of Sherwood, started to take shape the spring after I finished" +
                        " university. I was working at a castle in South Wales and commuting from Bristol every day to get there" +
                        " - on the long bus ride, and particularly the walk from station to castle, I played out these old scenarios" +
                        " in more detail. Slowly, characters began to emerge: Marian and Robin, nobly born and unwillingly betrothed" +
                        " since childhood; Will Scarlette, Robin's illegitimate half-brother, with a gift of the gab and charm that" +
                        " got him out of the danger his quick temper got him into; a Sheriff of Nottingham who might be self-serving" +
                        " but certainly was not a villain.</p>",
                    Content =
                        "<p>Somehow, five years passed. The characters were still somewhere in my" +
                        " mind, but they never got beyond a few hastily scribbled pages. I moved to London, got a job that I loved but" +
                        " took up too much mental space to leave any for writing, planned a wedding, got married. And that is when Robin" +
                        " appeared again. This time I was determined to tell his story properly. I had spent the intervening time working" +
                        " in incredible heritage sites, not least the Tower of London and Great Tower of Dover Castle, buildings that were" +
                        " old enough to have been seen by Robin and his friends when they were brand new. I had worked in medieval costume," +
                        " loosing catapults in a drained moat, running up and down spiral staircases, stood in the rain and mist while men" +
                        " careered about under the castle walls on horseback. And in order to do this job, I had researched more and more" +
                        " deeply the medieval period I was interpreting.</p>" +
                        "<p>I had also read and watched a fair amount of historical fiction - some of it brilliant, some of it dire. And" +
                        " what I wanted was to tell a story of Robin Hood that was not about a mythical figure,  witches or wood spirits or" +
                        " fat monks or leering knights, but instead was rooted in the twelfth century world I had come to know and love. An" +
                        " alien culture in many ways, where violence or its threat was never far removed, where death hung in the scales for" +
                        " thousands, to be decided by forces beyond their control - a vicious frost or sodden crops could wipe out whole" +
                        " families, and painted saints were the only intercessors they could rely on.  And into this world I dropped a man" +
                        " called Robin of Locksley, who would have to negotiate the law courts, ordeal, divided loyalties, brute force, and" +
                        " the distant but defiant rumbles of civil war.</p>"
                },
                new Product()
                {
                    Id = "AAOJ",
                    Title = "An Army of Judiths",
                    Author = "C.J. Underwood",
                    Abstract =
                        "<p>I first encountered the legend of Kenau Hasselaar when I overheard a professor and his students at the University" +
                        " of Leiden’s library in 1994, and was immediately captivated. The professor spoke about the savage sixteenth" +
                        " century Dutch Revolt against the invading Spanish King Phillip II, the revolt that inspired one woman’s fight" +
                        " to preserve the lifestyle that her family had nurtured for generations. Kenau’s battle was the seven-month" +
                        " Siege of Haarlem, 1572-1573. The professor recited the legend of this spirited aristocrat who had been driven" +
                        " to form an army of three hundred women soldiers. He said that Kenau had trained them to fight the Spanish back" +
                        " from the walls of Haarlem, but had refused to wear armour.</p>",
                    Content =
                        "<p>From the moment Kenau entered my consciousness, I determined to learn every possible detail about this" +
                        " inspirational female character, a woman that was grist to the mill of my own life story. Although I’d always" +
                        " written, I had spent my career at the time travelling a man’s world; I’d thought nothing of working as a chef" +
                        " in all-male brigades, and was the first woman in the British Merchant Navy to work in the North Sea.</p>" +
                        "<p>My first surprise was that in the Netherlands the name Kenau was synonymous with the derogative, Bitch." +
                        " If Kenau Hasselaar had indeed been a Dutch war heroine, I couldn’t understand why she was so maligned by" +
                        " modern Dutch society. After a thorough search of the Amsterdam women’s library, and various other institutions," +
                        " I was baffled to find nothing more solid than a couple of cursory, albeit reliable, reference works and some old," +
                        " unreliable stories of Kenau’s part in the siege. I found a tapestry of Kenau in Amsterdam’s Rijksmuseum," +
                        " but it wasn’t until some years later that paintings of Kenau Hasselaar were available online.</p>" +
                        "<p>It seemed to me that legends have a lot to answer for, after all these years the fable that Kenau Hasselaar" +
                        " was a dedicated cutthroat for the sake of it should have morphed into something more honourable. She may" +
                        " indeed have been a hellcat, but she must have been so much more besides. Some legends just beg interrogation.</p>"
                }
            };
            return products;
        }
    }
}
