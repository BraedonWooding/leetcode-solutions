# Write your MySQL query statement below
select name as NAME, sum(amount) as BALANCE
from Users u
join Transactions t on t.account = u.account
group by name
having sum(amount) > 10000