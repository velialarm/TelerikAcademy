//
//  Event.m
//  EventManager
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import "Event.h"

@implementation Event

- (id)init
{
    self = [super init];
    if (self) {
//        _title = @"Default";
//        _category = @"Default";
//        _description = @"Default event when init";
        _date = [NSDate date];
//        _guests = @[];
    }
    return self;
}

-(NSString *)description{
    NSString *res = [NSString stringWithFormat:@"Title: %@; description: %@; date:%@", _title, _description, _date];
    return res;
}
@end
