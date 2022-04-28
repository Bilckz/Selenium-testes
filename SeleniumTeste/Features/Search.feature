Feature: Search
	Article search tests

Scenario: existing snippet of an article
	Given I use the following snippet "quais métricas acompanhar?"
	When I search
	Then I verify that I found the article

Scenario: empty search
	Given I don't enter anything in the search field
	When I search
	Then I verify that the search brought up articles