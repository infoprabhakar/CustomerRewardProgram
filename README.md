# Customer Reward Program

Customer Reward Program API helps retailers to calculate rewarding points based on each recorded purchase as follows:
 
For every dollar spent over $50 on the transaction, the customer receives one point.
In addition, for every dollar spent over $100, the customer receives another point.
Ex: for a $120 purchase, the customer receives
(120 - 50) x 1 + (120 - 100) x 1 = 90 points

## Technologies Used
1. Codebase: .NET Core v.3.1

## Get reward points for each transaction based on price

### Request

`GET /GetRewardPoints?price={price}`

    curl -i -H 'Accept: application/json' https://localhost:5001/api/rewards/GetRewardPoints?price=120

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 36

    output: 90
    

## Get reward points monthly total per customer, and 3 months summary.

### Request

`GET /GetRewardPointMonthlySummary?noOfMonths={no of months}`

    curl -i -H 'Accept: application/json' https://localhost:5001/api/rewards/GetRewardPointMonthlySummary?noOfMonths=3

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 36

    {
    "customerwiseRewardSummaryDetail": [
        {
            "monthYear": "June 2022",
            "customerName": "John David",
            "rewardPoints": 250
        }
    ],
    "transactionSummaryDetail": [
        {
            "monthYear": "June 2022",
            "transactionDate": "2022-06-05T00:00:00",
            "customerName": "John David",
            "price": 200,
            "rewardPoints": 250
        }
    ]
}
 

## Get reward points monthly total per customer, and months summary based on dates

### Request

`GET /GetRewardPointSummaryByDate?startDateTime={startdate}&endDateTime={enddate}

    curl -i -H 'Accept: application/json' https://localhost:5001/api/rewards/GetRewardPointSummaryByDate?startDateTime=05/01/2022&endDateTime=08/31/2022

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 36

    {
    "customerwiseRewardSummaryDetail": [
        {
            "monthYear": "June 2022",
            "customerName": "John David",
            "rewardPoints": 250
        }
    ],
    "transactionSummaryDetail": [
        {
            "monthYear": "June 2022",
            "transactionDate": "2022-06-05T00:00:00",
            "customerName": "John David",
            "price": 200,
            "rewardPoints": 250
        }
    ]
}


### Postman GetRewardPointSummaryByDates Request
![GetRewardPointSummaryByDates](https://user-images.githubusercontent.com/14961097/188152980-3f1940eb-0a3a-4743-8303-0867ffae858c.JPG)

### Customer List
![Customers](https://user-images.githubusercontent.com/14961097/188153046-db7c49d6-77b4-4e05-9f3a-a2f7665ea497.JPG)

### Transaction List
![Transactions](https://user-images.githubusercontent.com/14961097/188153075-642b39ad-d45f-4f67-95a0-2e2ad6df2c96.JPG)

### GetRewardPointSummaryByDates Response
![Response](https://user-images.githubusercontent.com/14961097/188153112-0114bc57-5ef6-4280-8d84-e5657ad184ad.JPG)

