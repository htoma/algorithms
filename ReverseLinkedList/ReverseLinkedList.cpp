#include "stdafx.h"
#include <vector>
#include <iterator>
#include <iostream>

struct Node 
{
	int value;
	Node* next;
};

Node* populateList(std::vector<int> values)
{
	Node* head = NULL;
	Node* tmp = NULL;
	for (std::vector<int>::iterator it = values.begin(); it != values.end(); ++it)
	{
		Node* node = new Node();
		node->value = *it;
		node->next = NULL;
		if (head == NULL) 
		{
			head = node;
			tmp = head;
		}
		else
		{
			tmp->next = node;
			tmp = tmp->next;
		}
	}
	return head;
}

void printList(Node* head)
{
	Node* tmp = head;
	while (tmp != NULL) 
	{
		std::cout << tmp->value << " " << std::endl;
		tmp = tmp -> next;
	}
}

Node* reverseList(Node* head)
{
	if (head == NULL || head->next == NULL)
	{
		return head;
	}

	Node* p = head;
	Node* q = p->next;

	while (q != NULL)
	{
		p->next = q->next;
		q->next = head;
		head = q;
		q = p->next;
	}

	return head;
}

int _tmain(int argc, _TCHAR* argv[])
{
	int values[] = {16, 2, 77, 29};
    std::vector<int> vector (values, values + sizeof(values) / sizeof(int) );
	Node* head = populateList(vector);
	printList(reverseList(head));
	return 0;
}



