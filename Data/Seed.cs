using comic.Data;
using Microsoft.AspNetCore.Identity;

namespace comic.Models;

public class Seed
{
    public static void SeedData(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<ComicContext>();

            context.Database.EnsureCreated();

            //Category
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new List<Category>()
                {
                    new Category()
                    {
                        CategoryName = "comic"
                    },
                    new Category()
                    {
                        CategoryName = "literature"
                    },
                });

                context.SaveChanges();
            }

            //Tags
            var tags = new List<Tag>
            {
                new Tag() { TagName = "4-Koma" },
                new Tag() { TagName = "Adaptation" },
                new Tag() { TagName = "Anthology" },
                new Tag() { TagName = "Award Winning" },
                new Tag() { TagName = "Doujinshi" },
                new Tag() { TagName = "Fan Colored" },
                new Tag() { TagName = "Full Color" },
                new Tag() { TagName = "Long Strip" },
                new Tag() { TagName = "Official Colored" },
                new Tag() { TagName = "Oneshot" },
                new Tag() { TagName = "Self-Published" },
                new Tag() { TagName = "Web Comic" },
                new Tag() { TagName = "Suggestive" },
                new Tag() { TagName = "Action" },
                new Tag() { TagName = "Adventure" },
                new Tag() { TagName = "Yaoi" },
                new Tag() { TagName = "Comedy" },
                new Tag() { TagName = "Crime" },
                new Tag() { TagName = "Drama" },
                new Tag() { TagName = "Fantasy" },
                new Tag() { TagName = "Yuri" },
                new Tag() { TagName = "Historical" },
                new Tag() { TagName = "Horror" },
                new Tag() { TagName = "Isekai" },
                new Tag() { TagName = "Magical Girls" },
                new Tag() { TagName = "Mecha" },
                new Tag() { TagName = "Medical" },
                new Tag() { TagName = "Mystery" },
                new Tag() { TagName = "Sexual Violence" },
                new Tag() { TagName = "Philosophical" },
                new Tag() { TagName = "Psychological" },
                new Tag() { TagName = "Romance" },
                new Tag() { TagName = "Sci-Fi" },
                new Tag() { TagName = "Slice of Life" },
                new Tag() { TagName = "Sports" },
                new Tag() { TagName = "Superhero" },
                new Tag() { TagName = "Thriller" },
                new Tag() { TagName = "Tragedy" },
                new Tag() { TagName = "Wuxia" },
                new Tag() { TagName = "Aliens" },
                new Tag() { TagName = "Animals" },
                new Tag() { TagName = "Cooking" },
                new Tag() { TagName = "Crossdressing" },
                new Tag() { TagName = "Delinquents" },
                new Tag() { TagName = "Demons" },
                new Tag() { TagName = "Genderswap" },
                new Tag() { TagName = "Ghosts" },
                new Tag() { TagName = "Gyaru" },
                new Tag() { TagName = "Harem" },
                new Tag() { TagName = "Incest" },
                new Tag() { TagName = "Loli" },
                new Tag() { TagName = "Mafia" },
                new Tag() { TagName = "Magic" },
                new Tag() { TagName = "Martial Arts" },
                new Tag() { TagName = "Military" },
                new Tag() { TagName = "Monster Girls" },
                new Tag() { TagName = "Monsters" },
                new Tag() { TagName = "Music" },
                new Tag() { TagName = "Ninja" },
                new Tag() { TagName = "Office Workers" },
                new Tag() { TagName = "Police" },
                new Tag() { TagName = "Post-Apocalyptic" },
                new Tag() { TagName = "Reincarnation" },
                new Tag() { TagName = "Reverse Harem" },
                new Tag() { TagName = "Samurai" },
                new Tag() { TagName = "School Life" },
                new Tag() { TagName = "Shota" },
                new Tag() { TagName = "Supernatural" },
                new Tag() { TagName = "Survival" },
                new Tag() { TagName = "Time Travel" },
                new Tag() { TagName = "Traditional Games" },
                new Tag() { TagName = "Vampires" },
                new Tag() { TagName = "Video Games" },
                new Tag() { TagName = "Villainess" },
                new Tag() { TagName = "Virtual Reality" },
                new Tag() { TagName = "Zombies" },
                new Tag() { TagName = "Gore" },
            };

            if (!context.Tags.Any())
            {
                context.Tags.AddRange(tags);

                context.SaveChanges();
            }

            //Publishers
            if (!context.Publishers.Any())
            {
                context.Publishers.AddRange(new List<Publisher>()
                {
                    new Publisher() { PublisherName = "Bandai Namco" },
                    new Publisher() { PublisherName = "Kakao Studio" },
                    new Publisher() { PublisherName = "Kodansha" },
                    new Publisher() { PublisherName = "Shogakukan" },
                    new Publisher() { PublisherName = "Good Smile Company" },
                    new Publisher() { PublisherName = "Shueisha" },
                    new Publisher() { PublisherName = "Dark Horse Manga" },
                    new Publisher() { PublisherName = "VIZ" },
                });

                context.SaveChanges();
            }

            //Publishers
            if (!context.Publishers.Any())
            {
                context.Publishers.AddRange(new List<Publisher>()
                {
                    new Publisher() { PublisherName = "Bandai Namco" },
                    new Publisher() { PublisherName = "Kakao Studio" },
                    new Publisher() { PublisherName = "Kodansha" },
                    new Publisher() { PublisherName = "Shogakukan" },
                    new Publisher() { PublisherName = "Good Smile Company" },
                    new Publisher() { PublisherName = "Shueisha" },
                    new Publisher() { PublisherName = "Dark Horse Manga" },
                    new Publisher() { PublisherName = "VIZ" },
                });

                context.SaveChanges();
            }

            //StoreOwners
            if (!context.StoreOwners.Any())
            {
                context.StoreOwners.AddRange(new List<StoreOwner>()
                {
                    new StoreOwner()
                    {
                        Email = "abc@gmail.com",
                        Password = "123456789",
                        FirstName = "Kim",
                        LastName = "Dong",
                        PhoneNumber = "1234567890"
                    },
                });

                context.SaveChanges();
            }

            //StoreOwners
            if (!context.StoreOwners.Any())
            {
                context.StoreOwners.AddRange(new List<StoreOwner>()
                {
                    new StoreOwner()
                    {
                        Email = "abc@gmail.com",
                        Password = "123456789",
                        FirstName = "Kim",
                        LastName = "Dong",
                        PhoneNumber = "1234567890"
                    },
                });

                context.SaveChanges();
            }

            //Authors
            var authors = new List<Author>()
            {
                new Author() { AuthorName = "Egaki Numa" },

                new Author() { AuthorName = "h-goon (현군)" },
                new Author() { AuthorName = "Chugong (추공)" },
                new Author() { AuthorName = "Gi So-Ryeong (기소령)" },
                new Author() { AuthorName = "REDICE Studio (레드아이스 스튜디오)" },
                new Author() { AuthorName = "Jang Sung-Rak (장성락)" },

                new Author() { AuthorName = "Yamada Kanehito" },
                new Author() { AuthorName = "Abe Tsukasa" },

                new Author() { AuthorName = "Hyuuga Natsu" },
                new Author() { AuthorName = "Nanao Ikki" },
                new Author() { AuthorName = "Nekokurage" },

                new Author() { AuthorName = "Aneko Yusagi" },
                new Author() { AuthorName = "Aiya Kyu" },

                new Author() { AuthorName = "Tachibana Yuka" },
                new Author() { AuthorName = "Fujiazuki" },

                new Author() { AuthorName = "Inori." },
                new Author() { AuthorName = "Aono Shimo" },

                new Author() { AuthorName = "Nakamura Rikito" },
                new Author() { AuthorName = "Nozawa Yukiko" },

                new Author() { AuthorName = "Usonan (유소난)" },
                new Author() { AuthorName = "Wookjakga (욱작가)" },

                new Author() { AuthorName = "Akutami Gege" },

                new Author() { AuthorName = "Endou Tatsuya" },

                new Author() { AuthorName = "Kentaro Miura" },
                new Author() { AuthorName = "Mori Kouji" },
                new Author() { AuthorName = "Studio Gaga" },

                new Author() { AuthorName = "Inoue Takehiko" },
                new Author() { AuthorName = "Yoshikawa Eiji" },

                new Author() { AuthorName = "Jinushi" },

                new Author() { AuthorName = "Yamaguchi Tsubasa" },

                new Author() { AuthorName = "Araki Hirohiko" },

                new Author() { AuthorName = "Dongurisu" },
                new Author() { AuthorName = "Karasuma Ei (烏丸英)" },

                new Author() { AuthorName = "Jung SeonYul (정선율)" },
                new Author() { AuthorName = "Hess (헤스)" },
            };

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(authors);

                context.SaveChanges();
            }

            //Products
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>()
                {
                    new Product()
                    {
                        Name = "The Day I Decided to Make My Cheeky Gyaru Sister Understand in My Own Way",
                        PublisherId = 1,
                        Description = "",
                        Price = 11.49,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[12], // TagId 13
                            tags[30], // TagId 31
                        },
                        Authors = new List<Author>()
                        {
                            authors[0]
                        }
                    },

                    new Product()
                    {
                        Name = "Solo Leveling",
                        PublisherId = 2,
                        Description =
                            "10 years ago, after “the Gate” that connected the real world with the monster world opened, some of the ordinary, everyday people received the power to hunt monsters within the Gate...",
                        Price = 11.49,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[3], // TagId 4
                            tags[56], // TagId 57
                            tags[13], // TagId 14
                            tags[7], // TagId 8
                            tags[14], // TagId 15
                            tags[52], // TagId 53
                            tags[18], // TagId 19
                            tags[19], // TagId 20
                            tags[11], // TagId 12
                            tags[67], // TagId 68
                        },
                        Authors = new List<Author>()
                        {
                            authors[1],
                            authors[2],
                            authors[3],
                            authors[4],
                            authors[5],
                        }
                    },

                    new Product()
                    {
                        Name = "Sousou no Frieren Volume 1",
                        PublisherId = 4,
                        Description = "",
                        Price = 23.73,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[3], // TagId 4
                            tags[56], // TagId 57
                            tags[44], // TagId 45
                            tags[14], // TagId 15
                            tags[52], // TagId 53
                            tags[18], // TagId 19
                            tags[19], // TagId 20
                            tags[33], // TagId 34
                        },
                        Authors = new List<Author>()
                        {
                            authors[6],
                            authors[7],
                        }
                    },

                    new Product()
                    {
                        Name = "The Apothecary Diaries",
                        PublisherId = 3,
                        Description = "",
                        Price = 27.37,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[3], // TagId 4
                            tags[21], // TagId 22
                            tags[31], // TagId 32
                            tags[16], // TagId 17
                            tags[18], // TagId 19
                            tags[26], // TagId 27
                            tags[33], // TagId 34
                            tags[27], // TagId 28
                            tags[1], // TagId 2
                        },
                        Authors = new List<Author>()
                        {
                            authors[8],
                            authors[9],
                            authors[10],
                        }
                    },

                    new Product()
                    {
                        Name = "The Rising of the Shield Hero",
                        PublisherId = 6,
                        Description = "",
                        Price = 25.09,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[62], // TagId 63
                            tags[56], // TagId 57
                            tags[13], // TagId 14
                            tags[40], // TagId 41
                            tags[31], // TagId 32
                            tags[68], // TagId 69
                            tags[14], // TagId 15
                            tags[52], // TagId 53
                            tags[48], // TagId 49
                            tags[23], // TagId 24
                            tags[18], // TagId 19
                            tags[19], // TagId 20
                            tags[55], // TagId 56
                            tags[1], // TagId 2
                        },
                        Authors = new List<Author>()
                        {
                            authors[11],
                            authors[12],
                        }
                    },

                    new Product()
                    {
                        Name = "The Saints Magic Power Is Omnipotent",
                        PublisherId = 8,
                        Description =
                            "Sei, a 20 year old office worker, is summoned to a different world after finishing some overtime work...",
                        Price = 21.99,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[56], // TagId 57
                            tags[31], // TagId 32
                            tags[52], // TagId 53
                            tags[23], // TagId 24
                            tags[19], // TagId 20
                            tags[33], // TagId 34
                            tags[1], // TagId 2
                        },
                        Authors = new List<Author>()
                        {
                            authors[13],
                            authors[14],
                        }
                    },

                    new Product()
                    {
                        Name = "Im in Love with the Villainess.",
                        PublisherId = 7,
                        Description = "",
                        Price = 19.99,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[12], // TagId 13
                            tags[62], // TagId 63
                            tags[31], // TagId 32
                            tags[16], // TagId 17
                            tags[72], // TagId 73
                            tags[52], // TagId 53
                            tags[13], // TagId 14
                            tags[23], // TagId 24
                            tags[18], // TagId 19
                            tags[65], // TagId 66
                            tags[19], // TagId 20
                            tags[73], // TagId 74
                            tags[1], // TagId 2
                        },
                        Authors = new List<Author>()
                        {
                            authors[15],
                            authors[16],
                        }
                    },

                    new Product()
                    {
                        Name = "The 100 Girlfriends Who Really, Really, Really, Really, Really Love You",
                        PublisherId = 2,
                        Description = "",
                        Price = 26.77,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[12], // TagId 13
                            tags[3], // TagId 4
                            tags[31], // TagId 32
                            tags[16], // TagId 17
                            tags[48], // TagId 49
                            tags[65], // TagId 66
                            tags[33], // TagId 34
                            tags[67], // TagId 68
                        },
                        Authors = new List<Author>()
                        {
                            authors[17],
                            authors[18],
                        }
                    },

                    new Product()
                    {
                        Name = "A Returners Magic Should Be Special",
                        PublisherId = 8,
                        Description = "",
                        Price = 24.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[69], // TagId 70
                            tags[13], // TagId 14
                            tags[7], // TagId 8
                            tags[16], // TagId 17
                            tags[53], // TagId 54
                            tags[14], // TagId 15
                            tags[52], // TagId 53
                            tags[65], // TagId 66
                            tags[19], // TagId 20
                            tags[11], // TagId 12
                            tags[33], // TagId 34
                            tags[1], // TagId 2
                            tags[6], // TagId 7
                        },
                        Authors = new List<Author>()
                        {
                            authors[19],
                            authors[20],
                        }
                    },

                    new Product()
                    {
                        Name = "Jujutsu Kaisen",
                        PublisherId = 8,
                        Description = "",
                        Price = 19.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[76], // TagId 77
                            tags[36], // TagId 37
                            tags[56], // TagId 57
                            tags[13], // TagId 14
                            tags[46], // TagId 47
                            tags[53], // TagId 54
                            tags[52], // TagId 53
                            tags[19], // TagId 20
                            tags[64], // TagId 65
                            tags[67], // TagId 68
                        },
                        Authors = new List<Author>()
                        {
                            authors[21],
                        }
                    },

                    new Product()
                    {
                        Name = "SPY×FAMILY",
                        PublisherId = 3,
                        Description = "",
                        Price = 11.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[3], // TagId 4
                            tags[13], // TagId 14
                            tags[40], // TagId 41
                            tags[31], // TagId 32
                            tags[16], // TagId 17
                            tags[53], // TagId 54
                            tags[14], // TagId 15
                            tags[33], // TagId 34
                        },
                        Authors = new List<Author>()
                        {
                            authors[22],
                        }
                    },

                    new Product()
                    {
                        Name = "Berserk",
                        PublisherId = 8,
                        Description = "",
                        Price = 11.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[76], // TagId 77
                            tags[12], // TagId 13
                            tags[28], // TagId 29
                            tags[3], // TagId 4
                            tags[56], // TagId 57
                            tags[13], // TagId 14
                            tags[44], // TagId 45
                            tags[30], // TagId 31
                        },
                        Authors = new List<Author>()
                        {
                            authors[23],
                            authors[24],
                            authors[25],
                        }
                    },

                    new Product()
                    {
                        Name = "Vagabond",
                        PublisherId = 7,
                        Description = "",
                        Price = 30.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[76], // TagId 77
                            tags[28], // TagId 29
                            tags[3], // TagId 4
                            tags[21], // TagId 22
                            tags[13], // TagId 14
                            tags[30], // TagId 31
                            tags[53], // TagId 54
                        },
                        Authors = new List<Author>()
                        {
                            authors[26],
                            authors[27],
                        }
                    },

                    new Product()
                    {
                        Name = "Super no Ura de Yani Suu Futari",
                        PublisherId = 3,
                        Description = "",
                        Price = 25.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[3], // TagId 4
                            tags[31], // TagId 32
                            tags[16], // TagId 17
                            tags[59], // TagId 60
                            tags[33], // TagId 34
                            tags[11], // TagId 12
                        },
                        Authors = new List<Author>()
                        {
                            authors[28],
                        }
                    },

                    new Product()
                    {
                        Name = "Blue Period",
                        PublisherId = 3,
                        Description = "",
                        Price = 23.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[3], // TagId 4
                            tags[30], // TagId 31
                            tags[42], // TagId 43
                            tags[29], // TagId 30
                            tags[18], // TagId 19
                            tags[65], // TagId 66
                        },
                        Authors = new List<Author>()
                        {
                            authors[29],
                        }
                    },

                    new Product()
                    {
                        Name = "JoJo's Bizarre Adventure Part 7 - Steel Ball Run (Official Colored)",
                        PublisherId = 3,
                        Description = "",
                        Price = 30.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[3], // TagId 4
                            tags[8], // TagId 9
                            tags[21], // TagId 22
                            tags[13], // TagId 14
                            tags[30], // TagId 31
                            tags[16], // TagId 17
                            tags[53], // TagId 54
                            tags[14], // TagId 15
                        },
                        Authors = new List<Author>()
                        {
                            authors[30],
                        }
                    },

                    new Product()
                    {
                        Name =
                            "Nichiasa Suki no Otaku ga Akuyaku Seito ni Tenseishita Kekka, Hametsu Flag ga Houkaishiteiku Ken ni Tsuite",
                        PublisherId = 3,
                        Description = "",
                        Price = 30.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[12], // TagId 13
                            tags[13], // TagId 14
                            tags[16], // TagId 17
                            tags[18], // TagId 19
                            tags[19], // TagId 20
                            tags[23], // TagId 24
                            tags[35], // TagId 36
                        },
                        Authors = new List<Author>()
                        {
                            authors[31],
                            authors[32],
                        }
                    },

                    new Product()
                    {
                        Name = "I Obtained a Mythic Item",
                        PublisherId = 3,
                        Description = "",
                        Price = 30.67,
                        Inventory = 100,
                        CategoryId = 1,
                        StoreOwnerId = 1,
                        Tags = new List<Tag>
                        {
                            tags[69], // TagId 70
                            tags[56], // TagId 57
                            tags[13], // TagId 14
                            tags[7], // TagId 8
                            tags[14], // TagId 15
                            tags[52], // TagId 53
                            tags[18], // TagId 19
                            tags[19], // TagId 20
                            tags[11], // TagId 12
                            tags[67], // TagId 68
                        },
                        Authors = new List<Author>()
                        {
                            authors[33],
                            authors[34],
                        }
                    },
                });

                context.SaveChanges();
            }

            //Images
            if (!context.Images.Any())
            {
                context.Images.AddRange(new List<Image>()
                {
                    new Image()
                    {
                        ImageName = "5b90247b-7538-4d26-bdb7-bb18dc51cab0.jpg",
                        ProductId = 1
                    },

                    new Image()
                    {
                        ImageName = "e90bdc47-c8b9-4df7-b2c0-17641b645ee1.jpg",
                        ProductId = 2
                    },

                    new Image()
                    {
                        ImageName = "ff8a7f7e-c7fc-4633-8c4e-1efb76abc2be.jpg",
                        ProductId = 3
                    },

                    new Image()
                    {
                        ImageName = "d54cdbcc-0081-4773-82ae-893cde97e050.jpg",
                        ProductId = 4
                    },

                    new Image()
                    {
                        ImageName = "7847bc06-7b31-4a38-9bcd-c58002cd8808.jpg",
                        ProductId = 5
                    },

                    new Image()
                    {
                        ImageName = "c4beaf09-75d0-4a9c-9dfc-7ca7b08a190a.jpg",
                        ProductId = 6
                    },

                    new Image()
                    {
                        ImageName = "d30894c3-b90e-4225-8ac6-21c0ab094aff.jpg",
                        ProductId = 7
                    },

                    new Image()
                    {
                        ImageName = "cf612559-6bec-47ac-9230-1bc7686f88dd.jpg",
                        ProductId = 8
                    },

                    new Image()
                    {
                        ImageName = "98162533-1838-4639-8419-2f19f8af651b.png",
                        ProductId = 9
                    },

                    new Image()
                    {
                        ImageName = "5e54c679-75d5-4645-b69e-eb46e66f3870.jpg",
                        ProductId = 10
                    },

                    new Image()
                    {
                        ImageName = "7cac0992-5b89-4171-87cd-250c300a77d0.jpg",
                        ProductId = 11
                    },

                    new Image()
                    {
                        ImageName = "22ff2622-e93c-420f-b477-7a86eec02a1d.jpg",
                        ProductId = 12
                    },

                    new Image()
                    {
                        ImageName = "05f8dcb4-8ea1-48db-a0b1-3a8fbf695e5a.jpg",
                        ProductId = 13
                    },

                    new Image()
                    {
                        ImageName = "330a08d7-f6b1-4541-b958-443be3463887.jpg",
                        ProductId = 14
                    },

                    new Image()
                    {
                        ImageName = "fe570c0d-56d8-4213-8b6e-672282794001.jpg",
                        ProductId = 15
                    },

                    new Image()
                    {
                        ImageName = "e7e5e267-502f-4b77-9f19-b7ea1344f68f.jpg",
                        ProductId = 16
                    },

                    new Image()
                    {
                        ImageName = "e7242843-a694-453e-9089-9dcb214626e3.jpg",
                        ProductId = 17
                    },

                    new Image()
                    {
                        ImageName = "984ede4f-3628-4f4f-b904-ea968900de11.jpg",
                        ProductId = 18
                    },
                });

                context.SaveChanges();
            }
        }
    }

    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            //Roles
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //Users
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
            string adminUserEmail = "MisanropeHetCuu@gmail.com";

            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new User()
                {
                    UserName = "Misanrope",
                    Email = adminUserEmail,
                    FirstName = "Misanrope cc",
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(newAdminUser, "KhuaKhanh123@");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

            string appUserEmail = "user@etickets.com";

            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new User()
                {
                    UserName = "Ilaoi",
                    Email = appUserEmail,
                    FirstName = "Ilaoi",
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(newAppUser, "KhuaPhuc123!");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
    }
}