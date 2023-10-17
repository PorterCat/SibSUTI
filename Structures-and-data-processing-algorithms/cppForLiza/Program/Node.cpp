#include <iostream>
#include "Node.h"

Node::Node(int value)
{
	this->value = value;
	head = this;
	tail = head;
}

Node::~Node()
{
	std::cout << "Даун удалён";
}

void Node::Show()
{
	std::cout << this->value << '\n';
}
