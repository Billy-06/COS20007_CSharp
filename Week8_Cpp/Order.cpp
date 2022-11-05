//
// Created by billy on 3/11/2022.
//

#include "Order.h"

using namespace std;

Order::Order()= default;

Order::Order(const Order &original) {

}
Order::~Order()= default;

void Order::AddProduct(Product* product) {
    _products.push_back(product);
}

void Order::RemoveProduct(int index) {
    if (index < _products.size()){
        _products.erase( _products.begin() + 1 );
    }
    else {
        cout
                << "The index value you provided is out of range"
                << endl;
    }
}

vector<Product*> Order::getProducts() {
    return _products;
}

void Order::PrintOrders() {
    for(auto & _product : _products)
    {
        _product->PrintDetails();
    }
}
