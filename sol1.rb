# encoding: utf-8 

def integer_me(s, dic)
  s.map do |c|
    dic.index(c)
  end
end

def plus_one(nums, base)
  n = nums.reverse
  residuo = 1
  ans = n.map do |i|
    t = residuo
    residuo = (i+t)/base
    i = (i + t) % base
  end
  if residuo > 0
    ans << 0
  end
  ans.reverse
end

def string_me_plus_one(nums, dic)
  size = nums.size
  new_s = plus_one(nums, dic.size).join
  new_s.chars.map { |c| dic[c.to_i]}.join
end

dic = ('a'..'n').to_a + ['ñ'] + ('o'..'z').to_a

cases = gets.to_i

cases.times do
  puts string_me_plus_one(integer_me(gets.chomp.chars, dic), dic)
end

