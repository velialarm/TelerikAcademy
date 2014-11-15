//
//  AccessDB.m
//  DatabaseAccess
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import "AccessDB.h"
#import "Todo.h"

@implementation AccessDB
    
- (instancetype)init
{
    self = [super init];
    if (self) {
        NSLog(@"Access database. Connecting");
        _todota = [[NSMutableArray alloc]init];
    }
    return self;
}

- (void)dealloc
{
    NSLog(@"Destroy connection. Release database.");
}

-(void)addTodo:(NSString *)msg withEndDate:(NSDate *)date{
    Todo *todo = [[Todo alloc]init];
    [todo setMessage:msg];
    [todo setDate:date];
    [self.todota addObject:todo];
//    [_todota addObject:todo];
}

-(NSMutableArray *)showTodotas{
    return _todota;
}

@end
