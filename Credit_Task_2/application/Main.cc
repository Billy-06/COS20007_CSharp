#include <iostream>
#include "QueryInterface.h"

int main()
{
    QueryInterface* item = new QueryInterface();
    item->welcomePage();

    delete item;

    return 0;
}
