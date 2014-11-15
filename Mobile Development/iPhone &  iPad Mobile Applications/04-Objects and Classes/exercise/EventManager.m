//
//  EventManager.m
//  EventManager
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import "EventManager.h"

@implementation EventManager

- (id)init
{
    self = [super init];
    if (self) {
        //TODO
        _events = [[NSMutableArray alloc] init];
        
    }
    return self;
}

-(Event *)createEventWithTitle:(NSString *)title
                   andCategory:(NSString *)category
                andDescription:(NSString *)desc
                       andDate:(NSDate *)date
                     andGuests:(NSArray *)guests
{
    Event *event = [[Event alloc]init];
    [event setTitle:title];
    [event setCategory:category];
    [event setDescription:desc];
    [event setDate:date];
    [event setGuests:guests];
    
    return event;
}

-(void)addEvent:(Event *)ev{
    [_events addObject:ev];
}

-(NSMutableArray *)allEvents{
    return _events;
}

-(NSMutableArray *)allEventsByCategory:(NSString *)value{
    
    NSMutableArray *result = [[NSMutableArray alloc] init];
    
    for (Event *ev in _events) {
        if (ev.category == value) {
            [result addObject:ev];
        }
    }
    return result;
}

-(void)sortEventsByDate:(NSDate *)date orTitle:(NSString *)title{
    //TODO must implement
}


@end
