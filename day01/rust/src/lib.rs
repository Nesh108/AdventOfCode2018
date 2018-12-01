use std::collections::HashMap;

pub fn solve1a(input: Vec<i32>) -> i32 {
    let mut running_sum: i32 = 0;
    for num in input.iter() {
        running_sum += num
    }
    running_sum
}

pub fn solve1b(input: Vec<i32>) -> i32 {
    let mut seen_map: HashMap<i32, bool> = HashMap::new();
    seen_map.insert(0, true);
    solve1b_rec(input, seen_map, 0)
}

fn solve1b_rec(input: Vec<i32>, mut seen_map: HashMap<i32, bool>, prev_running_sum: i32) -> i32 {
    let mut running_sum: i32 = prev_running_sum;
    for num in input.iter() {
        running_sum += num;
        if seen_map.contains_key(&running_sum) {
            return running_sum;
        } else {
            seen_map.insert(running_sum, true);
        }
    }
    solve1b_rec(input, seen_map, running_sum)
}
