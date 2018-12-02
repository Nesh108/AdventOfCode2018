pub fn solve2a(input: Vec<&str>) -> i32 {
    let mut found_two_counter: i32 = 0;
    let mut found_three_counter: i32 = 0;
    for s in input.iter() {
        let mut found_two_times: bool = false;
        let mut found_three_times: bool = false;
        for (_, c) in s.chars().enumerate() {
            if !found_two_times || !found_three_times {
                let count_char = s.matches(c).count();
                if !found_two_times && count_char == 2 {
                    found_two_counter += 1;
                    found_two_times = true;
                }
                if !found_three_times && count_char == 3 {
                    found_three_counter += 1;
                    found_three_times = true;
                }
            } else {
                break;
            }
        }
    }
    found_two_counter * found_three_counter
}

pub fn solve2b(input: Vec<&str>) -> String {
    for i in 0..input.len() {
        for j in i + 1..input.len() {
            if let Some(similar) = get_common_letters(&input[i], &input[j]) {
                return similar;
            }
        }
    }
    String::from("")
}

fn get_common_letters(a: &str, b: &str) -> (Option<String>) {
    if a.len() != b.len() {
        return None;
    }

    let mut single_char_difference = false;
    for (c1, c2) in a.chars().zip(b.chars()) {
        if c1 != c2 {
            if single_char_difference {
                return None;
            }
            single_char_difference = true;
        }
    }
    Some(
        a.chars()
            .zip(b.chars())
            .filter(|&(c1, c2)| c1 == c2)
            .map(|(c, _)| c)
            .collect(),
    )
}
