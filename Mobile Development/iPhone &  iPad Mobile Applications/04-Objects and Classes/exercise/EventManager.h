//
//  EventManager.h
//  EventManager
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Event.h"

@interface EventManager : NSObject

@property NSMutableArray* events;

-(Event*) createEventWithTitle:(NSString*)title
                   andCategory:(NSString*)category
                andDescription:(NSString*)desc
                       andDate:(NSDate*)date
                     andGuests:(NSArray*)guests;

-(void) addEvent:(Event*)ev;

-(NSMutableArray*) allEvents;

-(NSMutableArray*) allEventsByCategory:(NSString*) value;

-(void) sortEventsByDate:(NSDate*) date
                 orTitle:(NSString*) title;

@end
