//
// Created by billy on 3/11/2022.
//

#include "Object.h"

Object::Object()
{
    _count++;
}

Object::Object(const Object&)
{
    _count++;
}

Object::~Object()
{
    _count--;
}

int Object::_count=0;

int Object::getCount()
{
    return _count;
}
