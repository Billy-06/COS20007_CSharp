//
// Created by billy on 3/11/2022.
//

#ifndef WEEK8_CPP_ORDER_H
#define WEEK8_CPP_ORDER_H


#include <iostream>
#include <vector>
#include "Product.h"

using namespace std;
class Order {
private:
    std::vector<Product*> _products;

public:
    Order();
    Order(const Order& original);
    ~Order();
    void AddProduct(Product* product );
    void RemoveProduct(int index);
    vector<Product*> getProducts();
    void PrintOrders();
};



#endif //WEEK8_CPP_ORDER_H
