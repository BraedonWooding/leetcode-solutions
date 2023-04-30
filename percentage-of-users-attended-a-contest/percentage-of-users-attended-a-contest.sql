# Write your MySQL query statement below
select contest_id, ROUND(count(c.user_id) / cast((select count(*) from Users) as float) * 100, 2) as percentage
from Users u
join Register c on u.user_id = c.user_id
group by contest_id
order by percentage desc, contest_id asc