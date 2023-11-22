using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Workshop5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) => 
    """
    create type user_role as enum
    (
        'admin',
        'employee',
        'customer'
    );

    create type order_state as enum
    (
        'created',
        'completed',
        'rejected'
    );

    create type order_result_state as enum
    (
        'completed',
        'rejected'
    );

    create table users
    (
        user_id bigint primary key generated always as identity ,
        user_name text not null ,
        user_role user_role not null 
    );

    create table shops
    (
        shop_id bigint primary key generated always as identity ,
        shop_name text not null 
    );

    create table product_categories
    (
        product_category_id bigint primary key generated always as identity ,
        product_category_name text not null 
    );

    create table products
    (
        product_id bigint primary key generated always as identity ,
        product_category_id bigint not null references product_categories(product_category_id),
        product_name text not null 
    );

    create table shop_products
    (
        shop_id bigint not null references shops(shop_id),
        product_id bigint not null references products(product_id),
        shop_product_price money not null ,
        
        primary key (shop_id, product_id)
    );

    create table orders
    (
        order_id bigint primary key generated always as identity ,
        order_state order_state not null ,
        shop_id bigint not null references shops(shop_id)
    );

    create table order_products
    (
        order_id bigint not null references orders(order_id),
        product_category_id bigint not null references product_categories(product_category_id),
        order_product_count int not null ,
        
        primary key (order_id, product_category_id)
    );

    create table order_results
    (
        order_id bigint not null references orders(order_id) primary key,
        order_result_state order_result_state not null ,
        order_result_cost money not null 
    );

    create table order_result_products
    (
        order_result_id bigint not null references order_results(order_id),
        product_id bigint not null references products(product_id),
        order_result_product_count int not null ,
        
        primary key (order_result_id, product_id)
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) => 
    """
    drop table users;
    drop table shops;
    drop table product_categories;
    drop table products;
    drop table shop_products;
    drop table orders; 
    drop table order_products;
    drop table order_results;
    drop table order_result_products;

    drop type user_role;
    drop type order_state;
    drop type order_result_state;
    """;
}