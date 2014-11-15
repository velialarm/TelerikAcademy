//
//  main.m
//  DatabaseAccess
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "AccessDB.h"
#import "Todo.h"

int main(int argc, const char * argv[])
{

    @autoreleasepool {
        
        AccessDB *db = [[AccessDB alloc] init];
        
        [db addTodo:@"Must cook.. " withEndDate:[NSDate date]];
        [db addTodo:@"learn german for 15 min. " withEndDate:[NSDate date]];
        [db addTodo:@"Create bomb. " withEndDate:[NSDate date]];
        
        NSMutableArray *res = [db showTodotas];
        for (Todo *todo in res) {
            NSLog(@"TODO: %@ | Date: %@", [todo message], [todo date]);
        }
        
    }
    return 0;
}

