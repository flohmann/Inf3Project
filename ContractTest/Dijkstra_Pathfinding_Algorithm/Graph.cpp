
#pragma once
#include "stdafx.h"
#include <vector>
#include "Graph.h"
using namespace std;

Graph::Graph()
{
}

void Graph::addNodes(Node n)
{
	if (&n == nullptr)
	{
		nodeList.push_back(n);
	}

}

bool Graph::hasNodes(Node n){
	
	if (&n != NULL){
		for each (Node node in nodeList)
		{
			if (node == n){
				isNode = true;
			}
		}
	}

	return isNode;
}

int Graph::getAmount(){
	return nodeList.size();
}

Node Graph::getNode(int x, int y){
	Node* n;
	unsigned i = 0;
	while (i < nodeList.size() && n == nullptr) {
		if ((nodeList[i].getX() == x) && (nodeList[i].getY() == y)) {
			n = &nodeList[i];
		}
	}
	return *n;
	/*for (Node node : nodeList){
		if ((node.getX() == x) && (node.getY() == y)) {
			return node;
		}
	}
	return ;*/
	//
}

std::vector<Node> Graph::getNodes(){
	return nodeList;
}

int Graph::getSize(){
	int max = 0;
	for (Node node : nodeList){
		if (node.getSize() > max){
			max = node.getSize();
		}
	}
	return max;
}

void Graph::setNodes(std::vector<Node> list){
	if ((&list == NULL) || list.size() < 1){
		printf("seNodes: invalid Liste");
	}
	nodeList = list;
}

Graph::~Graph()
{
	delete &nodeList;
}
