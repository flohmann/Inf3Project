// Dijkstra.cpp : Definiert die exportierten Funktionen für die DLL-Anwendung.
//

#include "stdafx.h"
#include "Dijkstra.h"


typedef int vertex_t;
typedef double weight_t;

const weight_t max_weight = std::numeric_limits<double>::infinity();



typedef std::vector<std::vector<neighbor> > adjacency_list_t;


void DijkstraComputePaths(vertex_t source,
	const adjacency_list_t &adjacency_list,
	std::vector<weight_t> &min_distance,
	std::vector<vertex_t> &previous)
{
	int n = adjacency_list.size();
	min_distance.clear();
	min_distance.resize(n, max_weight);
	min_distance[source] = 0;
	previous.clear();
	previous.resize(n, -1);
	std::set<std::pair<weight_t, vertex_t> > vertex_queue;
	vertex_queue.insert(std::make_pair(min_distance[source], source));

	while (!vertex_queue.empty())
	{
		weight_t dist = vertex_queue.begin()->first;
		vertex_t u = vertex_queue.begin()->second;
		vertex_queue.erase(vertex_queue.begin());

		// Visit each edge exiting u
		const std::vector<neighbor> &neighbors = adjacency_list[u];
		for (std::vector<neighbor>::const_iterator neighbor_iter = neighbors.begin();
			neighbor_iter != neighbors.end();
			neighbor_iter++)
		{
			vertex_t v = neighbor_iter->target;
			weight_t weight = neighbor_iter->weight;
			weight_t distance_through_u = dist + weight;
			if (distance_through_u < min_distance[v]) {
				vertex_queue.erase(std::make_pair(min_distance[v], v));

				min_distance[v] = distance_through_u;
				previous[v] = u;
				vertex_queue.insert(std::make_pair(min_distance[v], v));

			}

		}
	}
}


std::list<vertex_t> DijkstraGetShortestPathTo(
	vertex_t vertex, const std::vector<vertex_t> &previous)
{
	std::list<vertex_t> path;
	for (; vertex != -1; vertex = previous[vertex])
		path.push_front(vertex);
	return path;
}

int* findPath(int from, int to, int* map, int mapw, int maph, int &pathlength){
	// remember to insert edges both ways for an undirected graph
	adjacency_list_t adjacency_list(mapw * maph);

	for (int i = 0; i < (mapw * maph); i++){
		int row = i / mapw;
		int column = i % mapw;
		int left = row * mapw + (column - 1);
		int right = row * mapw + (column + 1);
		int above = (row - 1) * mapw + column;
		int under = (row + 1) * mapw + column;
		if (map[i] != 0){
			if (column - 1 >= 0 && map[left] != 0) adjacency_list[i].push_back(neighbor(left, 1));
			if (column + 1 <= (mapw - 1) && map[right] != 0) adjacency_list[i].push_back(neighbor(right, 1));
			if (row - 1 >= 0 && map[above] != 0) adjacency_list[i].push_back(neighbor(above, 1));
			if (row + 1 <= (maph - 1) && map[under] != 0) adjacency_list[i].push_back(neighbor(under, 1));
		}
	}

	std::vector<weight_t> min_distance;
	std::vector<vertex_t> previous;
	DijkstraComputePaths(from, adjacency_list, min_distance, previous);
	
	std::list<vertex_t> path = DijkstraGetShortestPathTo(to, previous);
		int* ar = new int[path.size()]; // create a dynamic array  
	std::copy(path.begin(), path.end(), ar);
	pathlength = path.size();

	return ar;
}

void release_Array(int* pArray)
{
	delete[] pArray;
}





