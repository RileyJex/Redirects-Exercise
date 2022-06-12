My solution to the redirects exercise.

Basic Assumptions:
Since it is not explicitly disallowed by the instructions, a route can have multiple redirects in and out of that route.

Solution:
The PathAnalyzer class implements the RouteAnalyzer interface and uses the Process method to create a graph of routes, where each node is
effectively a node in a linked list. As the graph is populated track which routes mark the beginning of a path and where each route redirects to. 

After the graph is constructed, check for cycles using a helper function that follows every path throughout the graph and tracks how many routes have been
visited. If we ever visit more routes than exist in the graph, there is a cycle.

Finally, use another helper function to construct each path from the bottom-up, returning a list of paths from that point in the graph. We only call this function on routes that we know are the beginning of a path.

Testing:
Unit tests are done using MSTest. All unit tests can be fount in "/Redirects Exercise Unit Tests/RedirectTests.cs".
