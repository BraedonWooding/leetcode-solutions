# Write your MySQL query statement below
select p.product_name, SUM(o.unit) as unit from
Products p
join Orders o on o.product_id = p.product_id
where o.order_date >= '2020-02-01' AND o.order_date < '2020-03-01'
group by p.product_name
having SUM(o.unit) >= 100