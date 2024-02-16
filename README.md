# MarketVerse - Your Ultimate E-commerce Solution

[![GitHub License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

MarketVerse is a powerful and feature-rich E-commerce platform developed using ASP.NET MVC. It provides both an admin panel and a user panel, designed to revolutionize the way you manage and operate your online store. With a wide range of features and an intuitive interface, MarketVerse is your one-stop solution for building a successful online marketplace.

## Features

- **Admin Panel**: Manage products, orders, customers, and more with ease.
- **User Panel**: Seamless shopping experience for customers with account management.
- **Product Catalog**: Display and categorize your products beautifully.
- **Order Management**: Efficiently process and track orders.
- **User Authentication**: Secure user accounts and sessions.
- **Payment Integration**: Support for various payment gateways.
- **Search Functionality**: Enable users to find products quickly.
- **Responsive Design**: Works seamlessly on all devices.
- **Customization**: Tailor MarketVerse to your specific needs.

## Getting Started

Follow these steps to get your MarketVerse project up and running on your local machine:

1. **Clone the repository**:
   git clone https://github.com/yourusername/market-verse.git
2. **Navigate to the project directory**:
  cd market-verse
3. **Database Setup**:
  Configure your database connection string in appsettings.json.
  Run database migrations to create the necessary tables:
  dotnet ef database update
4. **Run the Application**
  dotnet run
5. **Access the Application**:
Open your web browser and navigate to http://localhost:port.
6. **Creating Administrator Account**:
Open SqlServer and Create a new Admin Account.

## Contributing
We welcome contributions from the community. To contribute to MarketVerse, please follow these guidelines:
Fork the repository.
Create a new branch for your feature or bugfix.
Make your changes and submit a pull request.

## Modifying the Project
In order to change the Main Page Items and Add Different Products, you can Modify Models/PFMP.cs. 
<br/> 
Category's id is SubCategory's code. For example when you create a Category Called Electronics and its id is "1", you need to add 1 in the Code field to create SubCategory Based on that.
<br/>
After Creating a product, Open the Content Section and Create a new Content for it to prevent bugs.
## Pictures
