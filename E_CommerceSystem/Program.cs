using E_CommerceSystem.moodels;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystem
{
    internal class Program
    {
        static ECommerceContext context = new ECommerceContext();
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("        E-COMMERCE SYSTEM");
                Console.WriteLine("================================================");
                Console.WriteLine(" 1.Register a New User");
                Console.WriteLine(" 2.Add a New Product");
                Console.WriteLine(" 3.Place an Order");
                Console.WriteLine(" 4.Write a Product Review");
                Console.WriteLine(" 5.Update Product Price & Availability");
                Console.WriteLine(" 6.Cancel an Order");
                Console.WriteLine(" 7.Delete a Review");
                Console.WriteLine(" 8.View All Products");
                Console.WriteLine(" 9.Filter Products by Category & Price Range");
                Console.WriteLine("10.Get Category with All Its Products");
                Console.WriteLine("11.View Order History with Full Details");
                Console.WriteLine("12.Product Summary Report");
                Console.WriteLine(" 0.Exit");
                Console.WriteLine("================================================");
                Console.Write("Enter your choice: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            RegisterUser();
                            break;

                        case "2":
                            AddProduct();
                            break;

                        case "3":
                            PlaceOrder();
                            break;

                        case "4":
                            WriteReview();
                            break;

                        case "5":
                            UpdateProduct();
                            break;

                        case "6":
                            CancelOrder();
                            break;

                        case "7":
                            DeleteReview();
                            break;

                        case "8":
                            ViewAllProducts();
                            break;

                        case "9":
                            FilterProducts();
                            break;

                        case "10":
                            GetCategoryWithProducts();
                            break;

                        case "11":
                            ViewOrderHistory();
                            break;

                        case "12":
                            ProductSummaryReport();
                            break;

                        case "0":
                            running = false; Console.WriteLine("Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                //تسجيل مستخدم جديد
                static void RegisterUser()
                {
                    Console.WriteLine("Register a New User: ");

                    Console.Write("Enter username: ");
                    string username = Console.ReadLine().Trim();

                    // Duplicate username check
                    if (context.Users.Any(u => u.username == username))
                    {
                        Console.WriteLine("Error: Username already exists.");
                        return;
                    }

                    Console.Write("Enter email: ");
                    string email = Console.ReadLine().Trim();

                    if (context.Users.Any(u => u.email == email))
                    {
                        Console.WriteLine("Error: Email already exists.");
                        return;
                    }

                    Console.Write("Enter password: ");
                    string password = Console.ReadLine().Trim();

                    Console.Write("Enter full name: ");
                    string fullName = Console.ReadLine().Trim();

                    Console.Write("Enter phone (optional, press Enter to skip): ");
                    string phone = Console.ReadLine().Trim();

                    Console.Write("Enter address (optional, press Enter to skip): ");
                    string address = Console.ReadLine().Trim();

                    var newUser = new User
                    {
                        username = username,
                        email = email,
                        passwordHash = password,        // in production this would be hashed
                        fullName = fullName,
                        phoneNumber = string.IsNullOrWhiteSpace(phone) ? null : phone,
                        address = string.IsNullOrWhiteSpace(address) ? null : address,
                        registrationDate = DateTime.Now,    // system generated
                        isActive = true             // default value
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();                  // INSERT into Users table

                    Console.WriteLine($"" + $"User registered! Assigned userId: {newUser.userId}");
                }

                //إضافة منتج جديد إلى فئة معينة
                static void AddProduct()
                {
                    Console.WriteLine("Add a New Product: ");

                    // Show all categories so user can pick
                    var categories = context.Categories.ToList();
                    if (categories.Count == 0)
                    {
                        Console.WriteLine("Error: No categories found. Add a category first.");
                        return;
                    }

                    Console.WriteLine("Available Categories:");
                    categories.ForEach(c => Console.WriteLine($"ID: {c.categoryId} | {c.categoryName}"));

                    Console.Write("Enter Category ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int categoryId) || categoryId <= 0)
                    {
                        Console.WriteLine("Error: Invalid category ID.");
                        return;
                    }

                    if (!context.Categories.Any(c => c.categoryId == categoryId))
                    {
                        Console.WriteLine("Error: Category not found.");
                        return;
                    }

                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine().Trim();

                    Console.Write("Enter description (optional): ");
                    string desc = Console.ReadLine().Trim();

                    Console.Write("Enter price (OMR): ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price <= 0)
                    {
                        Console.WriteLine("Error: Invalid price.");
                        return;
                    }

                    Console.Write("Enter stock quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                    {
                        Console.WriteLine("Error: Invalid stock quantity.");
                        return;
                    }

                    var newProduct = new Product
                    {
                        productName = name,
                        description = string.IsNullOrWhiteSpace(desc) ? null : desc,
                        price = price,
                        stockQuantity = stock,
                        categoryId = categoryId,         // foreign key — links to chosen category
                        createdAt = DateTime.Now,       // system generated
                        isAvailable = true                // default value
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();                  // INSERT into Products table

                    Console.WriteLine($"Product added! Assigned productId: {newProduct.productId}");
                }

                static void PlaceOrder()
                {
                    Console.WriteLine("--- Place an Order ---");

                    // Pick user
                    Console.WriteLine("Registered Users:");
                    context.Users.Where(u => u.isActive).ToList()
                        .ForEach(u => Console.WriteLine($"  ID: {u.userId} | {u.fullName}"));

                    Console.Write("Enter User ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int userId)) { Console.WriteLine("Invalid."); return; }

                    var user = context.Users.FirstOrDefault(u => u.userId == userId);
                    if (user == null) { Console.WriteLine("Error: User not found."); return; }

                    Console.Write("Enter shipping address: ");
                    string shipping = Console.ReadLine().Trim();

                    Console.Write("Enter payment method (e.g. Credit Card): ");
                    string payment = Console.ReadLine().Trim();

                    // — Save Order first to get orderId
                    var newOrder = new Order
                    {
                        userId = userId,
                        orderDate = DateTime.Now,     // system generated
                        totalAmount = 0,                // will be calculated below
                        status = "Pending",        // default value
                        shippingAddress = shipping,
                        paymentMethod = payment
                    };

                    context.Orders.Add(newOrder);
                    context.SaveChanges();                  // INSERT Order — get orderId

                    decimal total = 0;
                    bool addingItems = true;

                    while (addingItems)
                    {
                        Console.WriteLine("Available Products:");
                        context.Products.Where(p => p.isAvailable && p.stockQuantity > 0).ToList()
                            .ForEach(p => Console.WriteLine($"  ID: {p.productId} | {p.productName} | OMR {p.price:F2} | Stock: {p.stockQuantity}"));

                        Console.Write("Enter Product ID to add (0 to finish): ");
                        if
                            (!int.TryParse(Console.ReadLine(), out int productId)) 
                            continue;
                        if
                            (productId == 0) 
                            break;

                        var product = context.Products.FirstOrDefault(p => p.productId == productId && p.isAvailable);
                        if 
                            (product == null) 
                        {
                            Console.WriteLine("Product not found."); 
                            continue; 
                        }

                        Console.Write("Enter quantity: ");
                        if 
                            (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                        { 
                            Console.WriteLine("Invalid quantity."); 
                            continue;
                        }

                        if 
                            (qty > product.stockQuantity)
                        {
                            Console.WriteLine($"Error: Only {product.stockQuantity} in stock."); 
                            continue; 
                        }

                        // Create OrderItem (bridge record)
                        var item = new OrderItem
                        {
                            orderId = newOrder.orderId,   // links to the saved order
                            productId = productId,
                            quantity = qty,
                            unitPrice = product.price       // calculated — copied at time of order
                        };

                        context.OrderItems.Add(item);       // INSERT into OrderItems

                        // Reduce stock
                        product.stockQuantity -= qty;       // UPDATE stockQuantity

                        total = item.unitPrice * qty;

                        context.SaveChanges();              // save item + stock change together
                        Console.WriteLine($"Added: {product.productName} {qty}");
                    }

                    // Update totalAmount on the order
                    newOrder.totalAmount = total;
                    context.SaveChanges();                  // UPDATE Order totalAmount

                    Console.WriteLine($" Order placed! OrderID: {newOrder.orderId} | Total: OMR {total:F2}");
                }

                static void WriteReview()
                {
                    Console.WriteLine("--- Write a Product Review ---");

                    Console.WriteLine("Users:");
                    context.Users.ToList().ForEach(u => Console.WriteLine($"  ID: {u.userId} | {u.fullName}"));
                    Console.Write("Enter User ID: ");
                    if
                      (!int.TryParse(Console.ReadLine(), out int userId))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }
                    if
                      (!context.Users.Any(u => u.userId == userId))
                    {
                        Console.WriteLine("User not found.");
                        return;
                    }

                    Console.WriteLine("Products:");
                    context.Products.ToList().ForEach(p => Console.WriteLine($"ID: {p.productId} | {p.productName}"));
                    Console.Write("Enter Product ID: ");
                    if
                      (!int.TryParse(Console.ReadLine(), out int productId))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    if
                        (!context.Products.Any(p => p.productId == productId))
                    {
                        Console.WriteLine("Product not found.");
                        return;
                    }

                    Console.Write("Enter rating (1-5): ");
                    if
                       (!int.TryParse(Console.ReadLine(), out int rating) || rating < 1 || rating > 5)
                    {
                        Console.WriteLine("Error: Rating must be 1-5.");
                        return;
                    }

                    Console.Write("Enter comment (optional, press Enter to skip): ");
                    string comment = Console.ReadLine().Trim();

                    var review = new Review
                    {
                        userId = userId,
                        productId = productId,
                        rating = rating,
                        comment = string.IsNullOrWhiteSpace(comment) ? null : comment,
                        reviewDate = DateTime.Now           // system generated

                    };

                    context.Reviews.Add(review);
                    context.SaveChanges();                  // INSERT into Reviews

                    Console.WriteLine($"Review submitted! ReviewID: {review.reviewId}");
                }

                static void UpdateProduct()
                {
                    Console.WriteLine("--- Update Product Price & Availability ---");

                    Console.Write("Enter Product ID to update: ");
                    if (!int.TryParse(Console.ReadLine(), out int productId)) { Console.WriteLine("Invalid."); return; }

                    // Fetch the tracked entity — EF Core will detect changes automatically
                    var product = context.Products.FirstOrDefault(p => p.productId == productId);
                    if (product == null) { Console.WriteLine("Error: Product not found."); return; }

                    Console.WriteLine($"Current price: OMR {product.price:F2} | Available: {product.isAvailable}");

                    Console.Write("Enter new price (OMR): ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal newPrice) || newPrice <= 0)
                    { Console.WriteLine("Error: Invalid price."); return; }

                    Console.Write("Is product available? (Y/N): ");
                    string input = Console.ReadLine().Trim().ToUpper();
                    if (input != "Y" && input != "N") { Console.WriteLine("Error: Enter Y or N."); return; }

                    // Update the tracked entity — no need to call Update() explicitly
                    product.price = newPrice;
                    product.isAvailable = (input == "Y");

                    context.SaveChanges();                  // EF Core sends UPDATE automatically

                    Console.WriteLine($"Product updated! New price: OMR {product.price:F2} | Available: {product.isAvailable}");
                }

                static void CancelOrder()
                {
                    Console.WriteLine("--- Cancel an Order ---");

                    Console.Write("Enter Order ID to cancel: ");
                    if
                       (!int.TryParse(Console.ReadLine(), out int orderId))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    var order = context.Orders.FirstOrDefault(o => o.orderId == orderId);
                    if
                       (order == null)
                    {
                        Console.WriteLine("Error: Order not found.");
                        return;
                    }

                    if
                       (order.status == "Cancelled")
                    {
                        Console.WriteLine("Error: Order is already cancelled.");
                        return;
                    }

                    if
                       (order.status == "Delivered")
                    {
                        Console.WriteLine("Error: Cannot cancel a delivered order.");
                        return;
                    }

                    // Load all OrderItems for this order
                    var items = context.OrderItems.Where(i => i.orderId == orderId).ToList();

                    // Restore stock for each product
                    foreach (var item in items)
                    {
                        var product = context.Products.FirstOrDefault(p => p.productId == item.productId);
                        if
                            (product != null)
                        {
                            product.stockQuantity += item.quantity;  // restore stock
                        }
                    }

                    // Update order status
                    order.status = "Cancelled";

                    context.SaveChanges();                  // UPDATE Order + all Product stocks

                    Console.WriteLine($"Order {orderId} cancelled. Stock restored for {items.Count} product(s).");
                }

                static void DeleteReview()
                {
                    Console.WriteLine("--- Delete a Review ---");

                    Console.Write("Enter Review ID to delete: ");
                    if
                        (!int.TryParse(Console.ReadLine(), out int reviewId))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    var review = context.Reviews.FirstOrDefault(r => r.reviewId == reviewId);
                    if (review == null)

                    {
                        Console.WriteLine("Error: Review not found.");
                        return;
                    }

                    Console.WriteLine($"Review by UserID {review.userId} | Rating: {review.rating} | \"{review.comment}\"");
                    Console.Write("Confirm delete? (Y/N): ");
                    if (Console.ReadLine().Trim().ToUpper() != "Y")

                    {
                        Console.WriteLine("Cancelled.");
                        return;
                    }

                    context.Reviews.Remove(review);
                    context.SaveChanges();                  // DELETE from Reviews

                    Console.WriteLine($"Review {reviewId} deleted successfully.");
                }

                static void ViewAllProducts()
                {
                    Console.WriteLine("--- All Products ---");

                    // Single query — SELECT * FROM Products
                    var products = context.Products.ToList();

                    if
                        (products.Count == 0)
                    {
                        Console.WriteLine("No products found.");
                        return;
                    }

                    Console.WriteLine($"{"ID",-5} {"Name",-25} {"Price",-12} {"Stock",-8} {"Available"}");
                    Console.WriteLine(new string('-', 65));
                    foreach (var p in products)
                    {
                        Console.WriteLine($"{p.productId,-5} {p.productName,-25} OMR {p.price,-8:F2} {p.stockQuantity,-8} {p.isAvailable}");
                    }
                    Console.WriteLine($"Total products: {products.Count}");

                }

                static void FilterProducts()
                {
                    Console.WriteLine("--- Filter Products by Category & Price Range ---");

                    Console.WriteLine("Categories:");
                    context.Categories.ToList().ForEach(c => Console.WriteLine($"  ID: {c.categoryId} | {c.categoryName}"));

                    Console.Write("Enter Category ID: ");
                    if
                        (!int.TryParse(Console.ReadLine(), out int catId))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    Console.Write("Enter minimum price: ");
                    if
                        (!decimal.TryParse(Console.ReadLine(), out decimal minPrice))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    Console.Write("Enter maximum price: ");
                    if
                        (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    // WHERE categoryId = ? AND price >= min AND price <= max, ORDER BY price ASC
                    var results = context.Products
                        .Where(p => p.categoryId == catId
                                 && p.price >= minPrice
                                 && p.price <= maxPrice)
                        .OrderBy(p => p.price)
                        .ToList();

                    if
                        (results.Count == 0)
                    {
                        Console.WriteLine("No products found for the selected criteria.");
                        return;
                    }

                    Console.WriteLine($"Found {results.Count} product(s):");
                    results.ForEach(p => Console.WriteLine($"  {p.productId} | {p.productName} | OMR {p.price:F2} | Stock: {p.stockQuantity}"));
                }

                static void GetCategoryWithProducts()
                {
                    Console.WriteLine("--- Category with All Its Products ---");

                    Console.Write("Enter Category ID: ");
                    if
                        (!int.TryParse(Console.ReadLine(), out int catId))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    // Include loads Products in the SAME query — no second query fires
                    var category = context.Categories
                        .Include(c => c.Products)
                        .FirstOrDefault(c => c.categoryId == catId);

                    if
                        (category == null)
                    {
                        Console.WriteLine("Error: Category not found.");
                        return;
                    }

                    Console.WriteLine($"Category: {category.categoryName}");
                    Console.WriteLine($"Description: {category.description ?? "N/A"}");
                    Console.WriteLine($"Products ({category.Products.Count}):");

                    if
                        (category.Products.Count == 0)
                    {
                        Console.WriteLine("  No products in this category yet.");
                        return;
                    }

                    category.Products.ToList().ForEach(p =>
                        Console.WriteLine($"  {p.productId} | {p.productName} | OMR {p.price:F2} | Available: {p.isAvailable}"));
                }

                static void ViewOrderHistory()
                {
                    Console.WriteLine("--- Order History with Full Details ---");

                    Console.Write("Enter User ID: ");
                    if
                        (!int.TryParse(Console.ReadLine(), out int userId))
                    {
                        Console.WriteLine("Invalid.");
                        return;
                    }

                    // Chained ThenInclude — loads User → Orders → OrderItems → Product in ONE query
                    var user = context.Users
                        .Include(u => u.Orders)
                            .ThenInclude(o => o.OrderItems)
                                .ThenInclude(i => i.product)
                        .FirstOrDefault(u => u.userId == userId);

                    if
                        (user == null)
                    {
                        Console.WriteLine("Error: User not found.");
                        return;
                    }

                    Console.WriteLine($"Order history for: {user.fullName}");

                    if
                        (!user.Orders.Any())
                    {
                        Console.WriteLine("No orders found.");
                        return;
                    }

                    foreach (var order in user.Orders)
                    {
                        Console.WriteLine($"Order #{order.orderId} | {order.orderDate:yyyy-MM-dd} | Status: {order.status} | Total: OMR {order.totalAmount:F2}");
                        Console.WriteLine($"  {'─',50}");

                        foreach (var item in order.OrderItems)
                        {
                            // item.product is already loaded — no extra query fires
                            Console.WriteLine($"{item.product.productName,-25} x{item.quantity}   OMR {item.unitPrice:F2}");
                        }
                    }

                }

                static void ProductSummaryReport()
                {
                    Console.WriteLine("--- Product Summary Report ---");

                    // ── Part A: Projection — executes as ONE SQL query ──
                    var report = context.Products
                        .Select(p => new
                        {
                            ProductName = p.productName,
                            CategoryName = p.category.categoryName,        // joined via FK
                            ReviewCount = p.Reviews.Count(),              // COUNT in SQL
                            AvgRating = p.Reviews.Any()
                            ? p.Reviews.Average(r => r.rating)
                             : 0.0,                        // AVG in SQL
                            Stock = p.stockQuantity
                        })
                        .ToList();

                    Console.WriteLine($"{"Product",-25} {"Category",-20} {"Reviews",-10} {"Avg Rating",-12} {"Stock"}");
                    Console.WriteLine(new string('-', 80));

                    foreach (var r in report)
                    {
                        Console.WriteLine($"{r.ProductName,-25} {r.CategoryName,-20} {r.ReviewCount,-10} {r.AvgRating,-12:F1} {r.Stock}");
                    }

                    // ── Part B: Lazy Loading demo ───────────────────────
                    Console.WriteLine("--- Lazy Loading Demo ---");
                    Console.WriteLine("Fetching ONE product without Include...");

                    // No .Include() — product.Reviews is NOT loaded yet
                    var singleProduct = context.Products.FirstOrDefault();

                    if 
                        (singleProduct != null)
                    {
                        Console.WriteLine($"Product loaded: {singleProduct.productName}");

                        // THIS LINE fires a SECOND query to the database 
                        // EF Core sends: SELECT * FROM Reviews WHERE productId = ?
                        var reviewCount = singleProduct.Reviews.Count;   // second query fires HERE

                        Console.WriteLine($"Review count (loaded lazily): {reviewCount}");
                        Console.WriteLine("NOTE: A separate SQL query fired when .Reviews was accessed above.");
                        Console.WriteLine("To see lazy loading work, ensure UseLazyLoadingProxies() is enabled in OnConfiguring.");
                    }
                }
            }
        }
    }
}

              

    

